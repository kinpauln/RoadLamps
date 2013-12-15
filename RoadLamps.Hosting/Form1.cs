using RoadLamps.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoadLamps.Hosting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool _tcpListening = true;
        private ServiceHost _servicehost = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            //HostRoadLampsService();

            TcpServerListen();
            toolStripStatusTcpListener.Text = "Listening Started";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseRoadLampsService();
        }

        private void TcpServerListen() {
            IPAddress ipAddress = IPAddress.Any;
            TcpListener tcpListener = new TcpListener(ipAddress, 13001);
            tcpListener.Start();

            while (_tcpListening)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                MyClient newClient = new MyClient(tcpClient, this);
                Thread t = new Thread(new ThreadStart(newClient.Communicate));
                t.Start();
            }  
        }

        #region WCF Service

        private void HostRoadLampsService()
        {
            //using (_servicehost = new ServiceHost(typeof(RoadLampsService)))
            //{
            _servicehost = new ServiceHost(typeof(RoadLampsService));
            this._servicehost.Opening += delegate
            {
                toolStripStatusHosting.Text = "Hosting";
            };
            this._servicehost.Opened += delegate
            {
                toolStripStatusHosting.Text = "Hosted";
            };
            this._servicehost.Open();
            //}
        }

        private void CloseRoadLampsService()
        {
            IDisposable disposible = this._servicehost as IDisposable;
            if (disposible != null)
                disposible.Dispose();
        }

        #endregion
        
        private void btnTCPListening_Click(object sender, EventArgs e)
        {
            Button btnobj = (Button)sender;
            if (btnobj.Text.Equals("Stop TCP Listening"))
            {
                _tcpListening = false;
                btnTCPListening.Text = "Start TCP Listening";
                toolStripStatusTcpListener.Text = "Listening Stopped";
            }
            else
            {
                _tcpListening = true;
                btnTCPListening.Text = "Stop TCP Listening";
                toolStripStatusTcpListener.Text = "Listening Started";
            }
        }
    }
}
