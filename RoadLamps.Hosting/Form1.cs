using RoadLamps.Service;
using System;
using System.Collections;
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
        private const int toplimit = 2000;
        public Form1()
        {
            InitializeComponent();
        }

        private bool _tcpListening = true;
        private Thread _thListener;
        private ServiceHost _servicehost = null;
        private TcpListener _tcpListener = null;
        private int _threadCount = 0;
        private HashSet<MyClient> _list = new HashSet<MyClient>();

        private void Form1_Load(object sender, EventArgs e)
        {
            HostRoadLampsService();

            _thListener = new Thread(new ThreadStart(TcpServerListen));
            _thListener.IsBackground = true;
            _thListener.Start();
            toolStripStatusTcpListener.Text = "Listening Started";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseRoadLampsService();
            StopListening();
        }

        private void TcpServerListen() {
            IPAddress ipAddress = IPAddress.Any;
            _tcpListener = new TcpListener(ipAddress, 13000);
            _tcpListener.Start();

            while (_tcpListening)
            {                
                TcpClient tcpClient = _tcpListener.AcceptTcpClient();

                if (_threadCount > toplimit)
                {
                    // tell Client it's been over 2000
                    continue;
                }
                MyClient newClient = new MyClient(tcpClient, this);
                Thread t = new Thread(new ThreadStart(newClient.Communicate));
                t.IsBackground = true;
                t.Start();
                _list.Add(newClient);

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
        private void StopListening()
        {
            IDisposable disposible = this._tcpListener as IDisposable;
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
