//
// Example 3 Basic Moves Rev 3
//
// This program demonstrates how to perform basic trap profile move.
//
// This program demonstrates the following types of motion:
// 1. Trapezoidal move 
// 2. Halt move
//
// This program assumes the following axis configuration:
// 1. Upon startup it will enable axis at Can Node ID 1, or
// as the first drive on the EtherCAT network, using the first
// available EtherCAT port, "eth0".
// 2. The motor has an encoder with an index
//
// This code also includes the following prerequisites:
// 1. The amplifier and motor must be preconfigured and set up properly to run.
// 2. The hardware enable switch must be installed and easily accessible
//
// As with any motion product extreme caution must used! Read and understand
// all parameter settings before attemping to send to amplifier.
//
//
// Copley Motion Objects are Copyright, 2002-2015, Copley Controls.
//
// For more information on Copley Motion products see:
// http://www.copleycontrols.com
//

// Added by Minh: Manual Jogging, Data logging and JSON pasrsing.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMLCOMLib;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EX3_BasicMoves
{
    public partial class BasicMoves : Form
    {
        //***************************************************
        //*
        //*  EtherCAT Network
        //*
        //***************************************************
        //// A negative node number refers to the drive's physical position on the network
        //// -1 for the first drive, -2 for the second, etc.
        //const int ECAT_NODE = -1;
        //EcatObj ecatObj;

        //***************************************************
        //
        //  CANOpen Network
        //
        //***************************************************
        const int X_AXIS_CAN_ADDRESS = 2;
        canOpenObj canOpen;
        
        AmpObj xAxisAmp;
        ProfileSettingsObj ProfileSettings;
        HomeSettingsObj Home;
        

        private int _point;

        ////**
        //for data transmission
        TcpListener mTCPListener;
        TcpClient mTCPClient;
        byte[] mRx;
        int i = 0;
        int j = 1000;
        int k = 200;
        //**/


        // Create a delegate to close down the application in a thread safe way
        delegate void CloseApp();


        public BasicMoves()
        {
            InitializeComponent();
            Console.WriteLine(i);

        }
        

        public void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //Initialize code here
                xAxisAmp = new AmpObj();
                ProfileSettings = new ProfileSettingsObj();

                //***************************************************
                //
                //  CANOpen Network
                //
                //***************************************************
                canOpen = new canOpenObj();
                //
                //**************************************************************************
                //* The next two lines of code are optional. If no bit rate is specified,
                //* then the default bit rate (1 Mbit per second) is used.  If no port name
                //* is specified, then CMO will use the first supported CAN card found and
                //* use channel 0 of that card.
                //**************************************************************************
                // Set the bit rate to 1 Mbit per second
                canOpen.BitRate = CML_BIT_RATES.BITRATE_1_Mbit_per_sec;
                // Indicate that channel 0 of a Copley CAN card should be used
                canOpen.PortName = "copley1";
                //// Indicate that channel 0 of a KVaser card should be used
                //canOpen.PortName = "kvaser0";
                //// Indicate that channel 0 of an IXXAT card should be used
                //canOpen.PortName = "IXXAT0";
                //// Indicate that channel 0 of an IXXAT card (V3.x or newer drivers) should be used
                //canOpen.PortName = "IXXATV30";
                //***************************************************
                //* Initialize the CAN card and network
                //***************************************************
                canOpen.Initialize();
                //***************************************************
                //* Initialize the amplifier
                //***************************************************
                xAxisAmp.Initialize(canOpen, X_AXIS_CAN_ADDRESS);


                //Code to replace vb handle statements
                JogPosButton.MouseUp += JogPosButton_MouseUp;
                JogPosButton.MouseDown += JogPosButton_MouseDown;
                JogNegButton.MouseUp += JogNegButton_MouseUp;
                JogNegButton.MouseDown += JogNegButton_MouseDown;
               


                //***************************************************
                //*
                //*  EtherCAT Network
                //*
                //***************************************************
                //ecatObj = new EcatObj();
                //
                //***************************************************
                //* The next line of code is optional. The port name is the IP address of 
                //* the Ethernet adapter. Alternatively, a shortcut name “eth” can be used 
                //* in conjunction with the adapter number. For example “eth0” for the first 
                //* Ethernet adapter, “eth1” for the second adapter. If no port name is 
                //* supplied, it will default to “eth0”.
                //**************************************************************************
                //// Indicate that the first Ethernet adapter is to be used
                //ecatObj.PortName = "eth0";
                //// Specify an IP address
                //ecatObj.PortName = "192.168.1.1";
                //
                //***************************************************
                //* Initialize the EtherCAT network
                //***************************************************
                //ecatObj.Initialize();
                //
                //***************************************************
                //* Initialize the amplifier
                //***************************************************
                //xAxisAmp.InitializeEcat(ecatObj, ECAT_NODE);
                //
                
                // Read velocity loop settings from the amp, use these as reasonble starting
                // points for the trajectory limits.
                VelocityTextBox.Text = Convert.ToString((xAxisAmp.VelocityLoopSettings.VelLoopMaxVel) / 10);
                AccelTextBox.Text = Convert.ToString((xAxisAmp.VelocityLoopSettings.VelLoopMaxAcc) / 10);
                DecelTextBox.Text = Convert.ToString((xAxisAmp.VelocityLoopSettings.VelLoopMaxDec) / 10);

                // Initialize home object with amplifier home settings 
                Home = xAxisAmp.HomeSettings;
                Timer1.Start();
                          
                
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        private void HomeAxisButton_Click(object sender, EventArgs e)
        {
            try
            {

            HomeAxisButton.Enabled = false;

            Home.HomeVelFast = (xAxisAmp.VelocityLoopSettings.VelLoopMaxVel) / 10;
            Home.HomeVelSlow = (xAxisAmp.VelocityLoopSettings.VelLoopMaxVel) / 15;
            Home.HomeAccel = xAxisAmp.VelocityLoopSettings.VelLoopMaxAcc / 10;
            Home.HomeMethod = CML_HOME_METHOD.CHOME_NONE;
            Home.HomeOffset = -1000;
            xAxisAmp.HomeSettings = Home;
            xAxisAmp.GoHome();
            xAxisAmp.WaitMoveDone(10000);

            doMoveButton.Enabled = true;

            HomeAxisButton.Enabled = true;
            }
        catch(Exception ex)
            {
            HomeAxisButton.Enabled = true;
            DisplayError(ex);
            }
        }

        private void enableButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (enableButton.Text == "Amp Disable")
                {
                    xAxisAmp.Disable();
                    enableButton.Text = "Amp Enable";
                }
                else
                {
                    xAxisAmp.Enable();
                    enableButton.Text = "Amp Disable";
                }
            }
            catch (Exception ex)
                {
                DisplayError(ex);
                }
        }
        ////*
        public void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //Read and display actual position 
                
                
                posTextBox.Text = Convert.ToString(xAxisAmp.PositionActual);
                VeltextBox.Text = Convert.ToString(xAxisAmp.VelocityActual);
                CurtextBox.Text = Convert.ToString(xAxisAmp.CurrentActual);
                //send position data
                
                    
                    //frm.frm1 = this;
                    
                
                //btnSend();
                if (_point < 50)
                {
                    chart1.Series[0].Points.Add(xAxisAmp.PositionActual);
                 
                }
                else
                {
                    chart1.Series[0].Points.RemoveAt(0);
                    chart1.Series[0].Points.Add(xAxisAmp.PositionActual);
                }
                
            }
            catch (Exception ex)
            {
                Timer1.Stop();
                DisplayError(ex);
            }

        }
        ///*/
        private void doMoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Double Distance;
                Distance = Convert.ToDouble(DistanceTextBox.Text);
                
                ProfileSettings = xAxisAmp.ProfileSettings; // read profile settings from amp

                //Set the profile type for move
                ProfileSettings.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;

                //Set the profile trajectory values 
                ProfileSettings.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
                ProfileSettings.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
                ProfileSettings.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

                // Update the amplier's profile settigns
                xAxisAmp.ProfileSettings = ProfileSettings;

                // Execute the move
                xAxisAmp.MoveRel(Distance);
                }
            catch (Exception ex)
            {
                doMoveButton.Enabled = true;
                HomeAxisButton.Enabled = true;
                DisplayError(ex);
            }
        }

        private void haltMoveButton_Click(object sender, EventArgs e)
        {
            try
            {

            doMoveButton.Enabled = false;
            HomeAxisButton.Enabled = false;

            //set halt mode desired before halting the move
            xAxisAmp.HaltMode = CML_HALT_MODE.HALT_DECEL;
            // now halt the move
            xAxisAmp.HaltMove();

            doMoveButton.Enabled = true;
            HomeAxisButton.Enabled = true;
            }
        catch (Exception ex)
            {
            doMoveButton.Enabled = true;
            HomeAxisButton.Enabled = true;
            DisplayError(ex);
        }
        }

        //Code for button with mouse pressed
        private void JogPosButton_MouseDown(System.Object eventSender, System.Windows.Forms.MouseEventArgs eventArgs)// Handles JogPosButton.MouseDown
        {
            try
            {
                //Sets velocity, acceleration, deceleration limits for move to inputed values
                ProfileSettings.ProfileType = CML_PROFILE_TYPE.PROFILE_VELOCITY;
                ProfileSettings.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
                ProfileSettings.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
                ProfileSettings.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

                //Store inputed parameters as the profile settings
                xAxisAmp.ProfileSettings = ProfileSettings;

                //Performs positive move. 1 indicates positive move, -1 indicates negative move
                xAxisAmp.MoveAbs(1);
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }

        }

        //Code for button with mouse depressed
        private void JogPosButton_MouseUp(System.Object eventSender, System.Windows.Forms.MouseEventArgs eventArgs)//Handles JogPosButton.MouseUp
        {
            try
            {
                ProfileSettings.ProfileType = CML_PROFILE_TYPE.PROFILE_VELOCITY;
                //Sets profile velocity to zero
                ProfileSettings.ProfileVel = 0;

                //Store inputed parameters as the profile settings
                xAxisAmp.ProfileSettings = ProfileSettings;

                //Performs move
                xAxisAmp.MoveAbs(1);
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }

        }


        //Code for button with mouse pressed
        private void JogNegButton_MouseDown(System.Object eventSender, System.Windows.Forms.MouseEventArgs eventArgs)// Handles JogNegButton.MouseDown
        {
            try
            {
                ProfileSettings.ProfileType = CML_PROFILE_TYPE.PROFILE_VELOCITY;
                //Sets velocity, acceleration, deceleration limits for move to inputed values
                ProfileSettings.ProfileAccel = Convert.ToDouble(AccelTextBox.Text);
                ProfileSettings.ProfileDecel = Convert.ToDouble(DecelTextBox.Text);
                ProfileSettings.ProfileVel = Convert.ToDouble(VelocityTextBox.Text);

                //Store inputed parameters as the profile settings
                xAxisAmp.ProfileSettings = ProfileSettings;

                //Performs negative move
                xAxisAmp.MoveAbs(-1);
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        //Code for button with mouse depressed
        private void JogNegButton_MouseUp(System.Object eventSender, System.Windows.Forms.MouseEventArgs eventArgs)// Handles JogNegButton.MouseUp
        {
            try
            {
                ProfileSettings.ProfileType = CML_PROFILE_TYPE.PROFILE_VELOCITY;
                //Sets profile velocity to zero
                ProfileSettings.ProfileVel = 0;

                //Store inputed parameters as the profile settings
                xAxisAmp.ProfileSettings = ProfileSettings;

                //Performs move
                xAxisAmp.MoveAbs(1);
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }
        /////*
        //data transmission

        IPAddress findMyIPV4Address()
        {
            string strThisHostName = string.Empty;
            IPHostEntry thisHostDNSEntry = null;
            IPAddress[] allIPsOfThisHost = null;
            IPAddress ipv4Ret = null;

            try
            {
                strThisHostName = System.Net.Dns.GetHostName();
                thisHostDNSEntry = System.Net.Dns.GetHostEntry(strThisHostName);
                allIPsOfThisHost = thisHostDNSEntry.AddressList;

                for (int idx = allIPsOfThisHost.Length - 1; idx >= 0; idx--)
                {
                    if (allIPsOfThisHost[idx].AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipv4Ret = allIPsOfThisHost[idx];
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            return ipv4Ret;
        }


        public class Transfer
        {
            
            public string posTransfer { get; set;}
            public string velTransfer { get; set;}
            public string ampTransfer { get; set;}
        }






        private void btnStartListening_Click(object sender, EventArgs e)
        {
            IPAddress ipaddr;
            int nPort;

            if (!int.TryParse(tbPort.Text, out nPort))
            {
                nPort = 23000;
            }
            if (!IPAddress.TryParse(tbIPAddress.Text, out ipaddr))
            {
                MessageBox.Show("Invalid IP address supplied.");
                return;
            }
            mTCPListener = new TcpListener(ipaddr, nPort);

            mTCPListener.Start();
           

            mTCPListener.BeginAcceptTcpClient(onCompleteAcceptTcpClient, mTCPListener);
            

        }

        void onCompleteAcceptTcpClient(IAsyncResult iar)
        {
            TcpListener tcpl = (TcpListener)iar.AsyncState;
            try
            {
                mTCPClient = tcpl.EndAcceptTcpClient(iar);

                printLine("Client Connected...");
                
                tcpl.BeginAcceptTcpClient(onCompleteAcceptTcpClient, tcpl);
                //Timer1.Start();
                
                mRx = new byte[512];
                mTCPClient.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadFromTCPClientStream, mTCPClient);
                

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void onCompleteReadFromTCPClientStream(IAsyncResult iar)
        {
            TcpClient tcpc;
            int nCountReadBytes = 0;
            string strRecv;

            try
            {
                tcpc = (TcpClient)iar.AsyncState;
                nCountReadBytes = tcpc.GetStream().EndRead(iar);

                if (nCountReadBytes == 0)
                {
                    MessageBox.Show("Client disconnected.");
                    return;
                }

                strRecv = Encoding.ASCII.GetString(mRx, 0, nCountReadBytes);

                printLine(strRecv);

                mRx = new byte[512];

                tcpc.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadFromTCPClientStream, tcpc);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btnSend2_Click(object sender, EventArgs e)
        {
            byte[] tx = new byte[512];
            /*
            i = Convert.ToInt32(DistanceTextBox.Text);
            DistanceTextBox.Text = Convert.ToString(++i);
            ////*/
            Transfer transfer = new Transfer()
            {

                velTransfer = VeltextBox.Text,
                ampTransfer = CurtextBox.Text,
                posTransfer = posTextBox.Text,
            };
            string json = JsonConvert.SerializeObject(transfer, Formatting.Indented);
            if (string.IsNullOrEmpty(json)) return;

            try
            {
                if (mTCPClient != null)
                {
                    if (mTCPClient.Client.Connected)
                    {
                        tx = Encoding.ASCII.GetBytes(json);
                        mTCPClient.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToClientStream, mTCPClient);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void printLine(string _strPrint)
        {
            tbConsoleOutput.Invoke(new Action<string>(doInvoke), _strPrint);
        }

        public void doInvoke(string _strPrint)
        {
            tbConsoleOutput.Text = _strPrint ;
        }

        private void onCompleteWriteToClientStream(IAsyncResult iar)
        {
            try
            {
                TcpClient tcpc = (TcpClient)iar.AsyncState;
                tcpc.GetStream().EndWrite(iar);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*/
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //i = ++i;
            DistanceTextBox.Text = Convert.ToString(++i);
        }
        */

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            xAxisAmp.Disable();
        }

        public void DisplayError(Exception ex)
        {
            DialogResult errormsgbox = DialogResult;
            MessageBox.Show("Error Message: " + ex.Message + "\n" + "Error Source: "
                + ex.Source, "CMO Error", MessageBoxButtons.RetryCancel);
            if (errormsgbox == DialogResult.Cancel)
            {
                // it is possible that this method was called from a thread other than the 
                // GUI thread - if this is the case we must use a delegate to close the application.
                //Dim d As New CloseApp(AddressOf ThreadSafeClose)
                CloseApp d = new CloseApp(ThreadSafeClose);
                this.Invoke(d);
            }
        }

        public void ThreadSafeClose()
        {
            //If the calling thread is different than the GUI thread, then use the
            //delegate to close the application, otherwise call close() directly
            if (this.InvokeRequired)
            {
                CloseApp d = new CloseApp(ThreadSafeClose);
                this.Invoke(d);
            }
            else
                Close();
        }

        private void btnFindIPv4IP_Click(object sender, EventArgs e)
        {
            IPAddress ipa = null;
            ipa = findMyIPV4Address();

            if (ipa != null)
            {
                tbIPAddress.Text = ipa.ToString();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.timer2.Stop();
            this.timer2.Enabled = false;
            byte[] tx = new byte[512];
            
            /*
            i = Convert.ToInt32(DistanceTextBox.Text);
            DistanceTextBox.Text = Convert.ToString(++i);
            ////*/
            Transfer transfer = new Transfer()
            {
                velTransfer = VeltextBox.Text,
                ampTransfer = CurtextBox.Text,
                posTransfer = posTextBox.Text,
            };
            string json = JsonConvert.SerializeObject(transfer, Formatting.Indented);
            
            if (string.IsNullOrEmpty(json)) return;

            try
            {
                if (mTCPClient != null)
                {
                    if (mTCPClient.Client.Connected)
                    {
                        tx = Encoding.ASCII.GetBytes(json);
                        mTCPClient.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToClientStream, mTCPClient);
                    }
                }
                
            }

            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.timer2.Enabled = true;
            this.timer2.Start();
        }
       

        private void BeginCom_Click(object sender, EventArgs e)
        {
            timer2.Start();
            i = Convert.ToInt32(DistanceTextBox.Text);
        }
    }
}

/*
i =  Convert.ToInt32(DistanceTextBox.Text);
                DistanceTextBox.Text = Convert.ToString(++i);
                */
