namespace EX3_BasicMoves
{
    partial class BasicMoves
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.HomeAxisButton = new System.Windows.Forms.Button();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.posTextBox = new System.Windows.Forms.TextBox();
            this.DecelTextBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.AccelTextBox = new System.Windows.Forms.TextBox();
            this.AccelerationLabel = new System.Windows.Forms.Label();
            this.enableButton = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.DistanceTextBox = new System.Windows.Forms.TextBox();
            this.VelocityTextBox = new System.Windows.Forms.TextBox();
            this.haltMoveButton = new System.Windows.Forms.Button();
            this.velocityLabel = new System.Windows.Forms.Label();
            this.doMoveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.CurtextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.VeltextBox = new System.Windows.Forms.TextBox();
            this.JogNegButton = new System.Windows.Forms.Button();
            this.JogPosButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BeginCom = new System.Windows.Forms.Button();
            this.btnFindIPv4IP = new System.Windows.Forms.Button();
            this.btnSend2 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbConsoleOutput = new System.Windows.Forms.TextBox();
            this.btnStartListening = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // HomeAxisButton
            // 
            this.HomeAxisButton.Location = new System.Drawing.Point(36, 53);
            this.HomeAxisButton.Name = "HomeAxisButton";
            this.HomeAxisButton.Size = new System.Drawing.Size(250, 32);
            this.HomeAxisButton.TabIndex = 42;
            this.HomeAxisButton.Text = "Home Axis";
            this.HomeAxisButton.Click += new System.EventHandler(this.HomeAxisButton_Click);
            // 
            // Label8
            // 
            this.Label8.Location = new System.Drawing.Point(229, 168);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(82, 16);
            this.Label8.TabIndex = 41;
            this.Label8.Text = "counts/s^2";
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(229, 96);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(71, 16);
            this.Label6.TabIndex = 39;
            this.Label6.Text = "counts/s";
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(229, 128);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(82, 16);
            this.Label7.TabIndex = 40;
            this.Label7.Text = "counts/s^2";
            // 
            // Timer1
            // 
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(229, 248);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(48, 16);
            this.Label5.TabIndex = 38;
            this.Label5.Text = "counts";
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(229, 208);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(48, 16);
            this.Label4.TabIndex = 37;
            this.Label4.Text = "counts";
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(13, 248);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(136, 16);
            this.Label3.TabIndex = 36;
            this.Label3.Text = "Actual Position";
            // 
            // posTextBox
            // 
            this.posTextBox.Location = new System.Drawing.Point(149, 248);
            this.posTextBox.Name = "posTextBox";
            this.posTextBox.ReadOnly = true;
            this.posTextBox.Size = new System.Drawing.Size(72, 20);
            this.posTextBox.TabIndex = 35;
            this.posTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DecelTextBox
            // 
            this.DecelTextBox.Location = new System.Drawing.Point(149, 168);
            this.DecelTextBox.Name = "DecelTextBox";
            this.DecelTextBox.Size = new System.Drawing.Size(72, 20);
            this.DecelTextBox.TabIndex = 34;
            this.DecelTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(13, 168);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 23);
            this.Label1.TabIndex = 33;
            this.Label1.Text = "Deceleration";
            // 
            // AccelTextBox
            // 
            this.AccelTextBox.Location = new System.Drawing.Point(149, 128);
            this.AccelTextBox.Name = "AccelTextBox";
            this.AccelTextBox.Size = new System.Drawing.Size(72, 20);
            this.AccelTextBox.TabIndex = 32;
            this.AccelTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // AccelerationLabel
            // 
            this.AccelerationLabel.Location = new System.Drawing.Point(13, 128);
            this.AccelerationLabel.Name = "AccelerationLabel";
            this.AccelerationLabel.Size = new System.Drawing.Size(100, 23);
            this.AccelerationLabel.TabIndex = 31;
            this.AccelerationLabel.Text = "Acceleration";
            // 
            // enableButton
            // 
            this.enableButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.enableButton.Location = new System.Drawing.Point(25, 19);
            this.enableButton.Name = "enableButton";
            this.enableButton.Size = new System.Drawing.Size(88, 28);
            this.enableButton.TabIndex = 30;
            this.enableButton.Text = "Amp Disable";
            this.enableButton.UseVisualStyleBackColor = false;
            this.enableButton.Click += new System.EventHandler(this.enableButton_Click);
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(13, 208);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(88, 16);
            this.Label2.TabIndex = 29;
            this.Label2.Text = "Move Distance ";
            // 
            // DistanceTextBox
            // 
            this.DistanceTextBox.Location = new System.Drawing.Point(149, 208);
            this.DistanceTextBox.Name = "DistanceTextBox";
            this.DistanceTextBox.Size = new System.Drawing.Size(72, 20);
            this.DistanceTextBox.TabIndex = 28;
            this.DistanceTextBox.Text = "1000";
            this.DistanceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // VelocityTextBox
            // 
            this.VelocityTextBox.Location = new System.Drawing.Point(149, 96);
            this.VelocityTextBox.Name = "VelocityTextBox";
            this.VelocityTextBox.Size = new System.Drawing.Size(72, 20);
            this.VelocityTextBox.TabIndex = 24;
            this.VelocityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // haltMoveButton
            // 
            this.haltMoveButton.Location = new System.Drawing.Point(148, 354);
            this.haltMoveButton.Name = "haltMoveButton";
            this.haltMoveButton.Size = new System.Drawing.Size(88, 32);
            this.haltMoveButton.TabIndex = 27;
            this.haltMoveButton.Text = "Halt Move";
            this.haltMoveButton.Click += new System.EventHandler(this.haltMoveButton_Click);
            // 
            // velocityLabel
            // 
            this.velocityLabel.Location = new System.Drawing.Point(13, 96);
            this.velocityLabel.Name = "velocityLabel";
            this.velocityLabel.Size = new System.Drawing.Size(64, 16);
            this.velocityLabel.TabIndex = 26;
            this.velocityLabel.Text = "Velocity";
            // 
            // doMoveButton
            // 
            this.doMoveButton.Enabled = false;
            this.doMoveButton.Location = new System.Drawing.Point(36, 354);
            this.doMoveButton.Name = "doMoveButton";
            this.doMoveButton.Size = new System.Drawing.Size(80, 32);
            this.doMoveButton.TabIndex = 25;
            this.doMoveButton.Text = "Do Move";
            this.doMoveButton.Click += new System.EventHandler(this.doMoveButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.CurtextBox);
            this.groupBox1.Controls.Add(this.enableButton);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.VeltextBox);
            this.groupBox1.Controls.Add(this.JogNegButton);
            this.groupBox1.Controls.Add(this.JogPosButton);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.HomeAxisButton);
            this.groupBox1.Controls.Add(this.haltMoveButton);
            this.groupBox1.Controls.Add(this.doMoveButton);
            this.groupBox1.Controls.Add(this.Label8);
            this.groupBox1.Controls.Add(this.velocityLabel);
            this.groupBox1.Controls.Add(this.Label6);
            this.groupBox1.Controls.Add(this.VelocityTextBox);
            this.groupBox1.Controls.Add(this.Label7);
            this.groupBox1.Controls.Add(this.DistanceTextBox);
            this.groupBox1.Controls.Add(this.Label5);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Controls.Add(this.Label4);
            this.groupBox1.Controls.Add(this.AccelerationLabel);
            this.groupBox1.Controls.Add(this.Label3);
            this.groupBox1.Controls.Add(this.AccelTextBox);
            this.groupBox1.Controls.Add(this.posTextBox);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.DecelTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 443);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual Operation";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(227, 324);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 52;
            this.label13.Text = "mA";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(14, 324);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 16);
            this.label12.TabIndex = 51;
            this.label12.Text = "Actual Current";
            // 
            // CurtextBox
            // 
            this.CurtextBox.Location = new System.Drawing.Point(149, 321);
            this.CurtextBox.Name = "CurtextBox";
            this.CurtextBox.ReadOnly = true;
            this.CurtextBox.Size = new System.Drawing.Size(72, 20);
            this.CurtextBox.TabIndex = 50;
            this.CurtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(14, 289);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 16);
            this.label11.TabIndex = 49;
            this.label11.Text = "Actual Velocity";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(227, 289);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 16);
            this.label10.TabIndex = 48;
            this.label10.Text = "counts/s";
            // 
            // VeltextBox
            // 
            this.VeltextBox.Location = new System.Drawing.Point(149, 286);
            this.VeltextBox.Name = "VeltextBox";
            this.VeltextBox.ReadOnly = true;
            this.VeltextBox.Size = new System.Drawing.Size(72, 20);
            this.VeltextBox.TabIndex = 47;
            this.VeltextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // JogNegButton
            // 
            this.JogNegButton.BackColor = System.Drawing.SystemColors.Control;
            this.JogNegButton.Location = new System.Drawing.Point(148, 401);
            this.JogNegButton.Name = "JogNegButton";
            this.JogNegButton.Size = new System.Drawing.Size(88, 34);
            this.JogNegButton.TabIndex = 46;
            this.JogNegButton.Text = "Jog Neg";
            this.JogNegButton.UseVisualStyleBackColor = false;
            // 
            // JogPosButton
            // 
            this.JogPosButton.BackColor = System.Drawing.SystemColors.Control;
            this.JogPosButton.Location = new System.Drawing.Point(36, 401);
            this.JogPosButton.Name = "JogPosButton";
            this.JogPosButton.Size = new System.Drawing.Size(80, 34);
            this.JogPosButton.TabIndex = 45;
            this.JogPosButton.Text = "Jog Pos";
            this.JogPosButton.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(249, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 16);
            this.label9.TabIndex = 44;
            this.label9.Text = "Motor";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Motor 1",
            "Motor 2",
            "Motor 3",
            "Motor 4"});
            this.comboBox1.Location = new System.Drawing.Point(133, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(104, 21);
            this.comboBox1.TabIndex = 44;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chart1);
            this.groupBox2.Location = new System.Drawing.Point(375, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 207);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sensor Feedback";
            // 
            // BeginCom
            // 
            this.BeginCom.Location = new System.Drawing.Point(20, 151);
            this.BeginCom.Name = "BeginCom";
            this.BeginCom.Size = new System.Drawing.Size(200, 65);
            this.BeginCom.TabIndex = 23;
            this.BeginCom.Text = "Begin Transfer";
            this.BeginCom.UseVisualStyleBackColor = true;
            this.BeginCom.Click += new System.EventHandler(this.BeginCom_Click);
            // 
            // btnFindIPv4IP
            // 
            this.btnFindIPv4IP.Location = new System.Drawing.Point(333, 35);
            this.btnFindIPv4IP.Name = "btnFindIPv4IP";
            this.btnFindIPv4IP.Size = new System.Drawing.Size(81, 26);
            this.btnFindIPv4IP.TabIndex = 22;
            this.btnFindIPv4IP.Text = "Find IP";
            this.btnFindIPv4IP.UseVisualStyleBackColor = true;
            this.btnFindIPv4IP.Click += new System.EventHandler(this.btnFindIPv4IP_Click);
            // 
            // btnSend2
            // 
            this.btnSend2.Location = new System.Drawing.Point(358, 236);
            this.btnSend2.Name = "btnSend2";
            this.btnSend2.Size = new System.Drawing.Size(75, 23);
            this.btnSend2.TabIndex = 21;
            this.btnSend2.Text = "Send";
            this.btnSend2.UseVisualStyleBackColor = true;
            this.btnSend2.Click += new System.EventHandler(this.btnSend2_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 81);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "Connection Status";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(252, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Port";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "IP Address";
            // 
            // tbConsoleOutput
            // 
            this.tbConsoleOutput.Location = new System.Drawing.Point(20, 97);
            this.tbConsoleOutput.Multiline = true;
            this.tbConsoleOutput.Name = "tbConsoleOutput";
            this.tbConsoleOutput.Size = new System.Drawing.Size(200, 33);
            this.tbConsoleOutput.TabIndex = 17;
            // 
            // btnStartListening
            // 
            this.btnStartListening.Location = new System.Drawing.Point(242, 97);
            this.btnStartListening.Name = "btnStartListening";
            this.btnStartListening.Size = new System.Drawing.Size(178, 33);
            this.btnStartListening.TabIndex = 16;
            this.btnStartListening.Text = "Start Listening";
            this.btnStartListening.UseVisualStyleBackColor = true;
            this.btnStartListening.Click += new System.EventHandler(this.btnStartListening_Click);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(255, 41);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(48, 20);
            this.tbPort.TabIndex = 15;
            this.tbPort.Text = "23000";
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(20, 41);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(200, 20);
            this.tbIPAddress.TabIndex = 13;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(6, 25);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(408, 166);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSend2);
            this.groupBox3.Controls.Add(this.BeginCom);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.btnFindIPv4IP);
            this.groupBox3.Controls.Add(this.btnStartListening);
            this.groupBox3.Controls.Add(this.tbConsoleOutput);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.tbIPAddress);
            this.groupBox3.Controls.Add(this.tbPort);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Location = new System.Drawing.Point(375, 239);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(433, 266);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Communication";
            // 
            // BasicMoves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 653);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BasicMoves";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button HomeAxisButton;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Timer Timer1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox posTextBox;
        internal System.Windows.Forms.TextBox DecelTextBox;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox AccelTextBox;
        internal System.Windows.Forms.Label AccelerationLabel;
        internal System.Windows.Forms.Button enableButton;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox DistanceTextBox;
        internal System.Windows.Forms.TextBox VelocityTextBox;
        internal System.Windows.Forms.Button haltMoveButton;
        internal System.Windows.Forms.Label velocityLabel;
        internal System.Windows.Forms.Button doMoveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button JogNegButton;
        private System.Windows.Forms.Button JogPosButton;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox VeltextBox;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox CurtextBox;
        internal System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.Button btnStartListening;
        private System.Windows.Forms.TextBox tbConsoleOutput;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSend2;
        private System.Windows.Forms.Button btnFindIPv4IP;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button BeginCom;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

