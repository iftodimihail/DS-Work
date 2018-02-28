using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace SocketServer
{
    /// <summary>
    /// Summary description for SocketServerForm.
    /// </summary>
    public class SocketServerForm : System.Windows.Forms.Form
    {
        public AsyncCallback pfnWorkerCallBack;
        public Socket listenerSocket;
        public List<Socket> workerSockets = new List<Socket>();
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPortNo;
        private System.Windows.Forms.Button cmdListen;
        private System.Windows.Forms.TextBox txtDataRx;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDataTx;
        private System.Windows.Forms.Button button1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        

        public SocketServerForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdListen = new System.Windows.Forms.Button();
            this.txtPortNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataRx = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDataTx = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdListen);
            this.groupBox1.Controls.Add(this.txtPortNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // cmdListen
            // 
            this.cmdListen.Location = new System.Drawing.Point(144, 16);
            this.cmdListen.Name = "cmdListen";
            this.cmdListen.Size = new System.Drawing.Size(104, 24);
            this.cmdListen.TabIndex = 2;
            this.cmdListen.Text = "Start Listening";
            this.cmdListen.Click += new System.EventHandler(this.cmdListen_Click);
            // 
            // txtPortNo
            // 
            this.txtPortNo.Location = new System.Drawing.Point(96, 16);
            this.txtPortNo.Name = "txtPortNo";
            this.txtPortNo.Size = new System.Drawing.Size(40, 20);
            this.txtPortNo.TabIndex = 1;
            this.txtPortNo.Text = "8000";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port Number:";
            // 
            // txtDataRx
            // 
            this.txtDataRx.Enabled = false;
            this.txtDataRx.Location = new System.Drawing.Point(8, 264);
            this.txtDataRx.Multiline = true;
            this.txtDataRx.Name = "txtDataRx";
            this.txtDataRx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDataRx.Size = new System.Drawing.Size(272, 80);
            this.txtDataRx.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtDataTx);
            this.groupBox2.Location = new System.Drawing.Point(8, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 152);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send Data";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // txtDataTx
            // 
            this.txtDataTx.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDataTx.Location = new System.Drawing.Point(8, 16);
            this.txtDataTx.Multiline = true;
            this.txtDataTx.Name = "txtDataTx";
            this.txtDataTx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDataTx.Size = new System.Drawing.Size(240, 96);
            this.txtDataTx.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(0, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(288, 112);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Received";
            // 
            // SocketServerForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(296, 349);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtDataRx);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "SocketServerForm";
            this.Text = "Socket Server in C#";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new SocketServerForm());
        }

        private void cmdListen_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Create the listening socket...
                listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, int.Parse(this.txtPortNo.Text));
                
                // Bind to local IP Address...
                listenerSocket.Bind(ipLocal);
                
                // Start listening...
                listenerSocket.Listen(4);

                // Disable the listen button
                cmdListen.Enabled = false;
                
                // Create the call back for any client connections...
                listenerSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);

            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }
        
        public void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                //// To start listening again
                Socket currentWorker = listenerSocket.EndAccept(asyn);
                WaitForData(currentWorker);

                workerSockets.Add(currentWorker);

                listenerSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }

        }
        public class CSocketPacket
        {
            public System.Net.Sockets.Socket thisSocket;
            public byte[] dataBuffer = new byte[1];
        }

        public void WaitForData(System.Net.Sockets.Socket soc)
        {
            try
            {
                if (pfnWorkerCallBack == null)
                {
                    pfnWorkerCallBack = new AsyncCallback(OnDataReceived);
                }
                CSocketPacket theSocPkt = new CSocketPacket();
                theSocPkt.thisSocket = soc;
                // now start to listen for any data...
                soc.BeginReceive(theSocPkt.dataBuffer, 0, theSocPkt.dataBuffer.Length, SocketFlags.None, pfnWorkerCallBack, theSocPkt);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            txtDataRx.Text += value;
        }

        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                CSocketPacket theSockId = (CSocketPacket)asyn.AsyncState;
                //end receive...
                int iRx = 0;
                iRx = theSockId.thisSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
                System.String szData = new System.String(chars);
                //txtDataRx.Text = txtDataRx.Text + szData;

                AppendTextBox(szData);
                //broadcastData(szData);

                WaitForData(theSockId.thisSocket);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        /**
         * Sends the message to all the clients
         */
        private void broadcastData(string str, bool addNewline = false)
        {
            if (addNewline)
                str += Environment.NewLine;

            byte[] data = Encoding.ASCII.GetBytes(str);
            foreach (Socket client in workerSockets)
                client.Send(data);
        }

        private void buttonSend_Click(object sender, System.EventArgs e)
        {
            try
            {
                broadcastData(txtDataTx.Text, true);
                txtDataTx.Clear();
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }
    }
}
