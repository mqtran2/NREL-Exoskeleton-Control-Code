using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace TCPClient01
{
    public partial class Form1 : Form
    {
        TcpClient mTcpClient;
        byte[] mRx;

        public Form1()
        {
            InitializeComponent();
        }
        public class Transfer
        {

            public string posTransfer { get; set; }
            public string velTransfer { get; set; }
            public string ampTransfer { get; set; }
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPAddress ipa;
            int nPort;

            try
            {
                if (string.IsNullOrEmpty(tbServerIP.Text) || string.IsNullOrEmpty(tbServerPort.Text))
                    return;
                if (!IPAddress.TryParse(tbServerIP.Text, out ipa))
                {
                    MessageBox.Show("Please supply an IP Address.");
                    return;
                }

                if (!int.TryParse(tbServerPort.Text, out nPort))
                {
                    nPort = 23000;
                }

                mTcpClient = new TcpClient();
                mTcpClient.BeginConnect(ipa, nPort, onCompleteConnect, mTcpClient);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        void onCompleteConnect(IAsyncResult iar)
        {
            TcpClient tcpc;

            try
            {
                tcpc = (TcpClient)iar.AsyncState;
                tcpc.EndConnect(iar);
                mRx = new byte[512];
                tcpc.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadFromServerStream, tcpc);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        void onCompleteReadFromServerStream(IAsyncResult iar)
        {
            TcpClient tcpc;
            int nCountBytesReceivedFromServer;
            string strReceived;

            try
            {
                tcpc = (TcpClient)iar.AsyncState;
                nCountBytesReceivedFromServer = tcpc.GetStream().EndRead(iar);

                if (nCountBytesReceivedFromServer == 0)
                {
                    MessageBox.Show("Connection broken.");
                    return;
                }
                strReceived = Encoding.ASCII.GetString(mRx, 0, nCountBytesReceivedFromServer);
                
                Transfer transfer = JsonConvert.DeserializeObject<Transfer>(strReceived);
                printLine(transfer.posTransfer);
                printLine2(transfer.velTransfer);
                printLine3(transfer.ampTransfer);
                mRx = new byte[512];
                tcpc.GetStream().BeginRead(mRx, 0, mRx.Length, onCompleteReadFromServerStream, tcpc);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void printLine(string _strPrint)
        {
            tbConsole.Invoke(new Action<string>(doInvoke), _strPrint);
        }

        public void doInvoke(string _strPrint)
        {
            tbConsole.Text = _strPrint; //+ Environment.NewLine + tbConsole.Text ;
        }
        //tbConsole2
        public void printLine2(string _strPrint2)
        {
            tbConsole2.Invoke(new Action<string>(doInvoke2), _strPrint2);
        }

        public void doInvoke2(string _strPrint2)
        {
            tbConsole2.Text = _strPrint2; //+ Environment.NewLine + tbConsole.Text ;
        }
        //tbCOnsole3
        public void printLine3(string _strPrint3)
        {
            tbConsole3.Invoke(new Action<string>(doInvoke3), _strPrint3);
        }

        public void doInvoke3(string _strPrint)
        {
            tbConsole3.Text = _strPrint; //+ Environment.NewLine + tbConsole.Text ;
        }


        private void tbSend_Click(object sender, EventArgs e)
        {
            byte[] tx;
            
            if (string.IsNullOrEmpty(tbPayload.Text)) return;

            try
            {
                tx = Encoding.ASCII.GetBytes(tbPayload.Text);

                if (mTcpClient != null)
                {
                    if (mTcpClient.Client.Connected)
                    {
                        mTcpClient.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToServer, mTcpClient);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        void onCompleteWriteToServer(IAsyncResult iar)
        {
            TcpClient tcpc;

            try
            {
                tcpc = (TcpClient)iar.AsyncState;
                tcpc.GetStream().EndWrite(iar);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        
    }
}
