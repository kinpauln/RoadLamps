using RoadLamps.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
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

        private ServiceHost _servicehost = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            HostRoadLampsService();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseRoadLampsService();
        }

        #region service

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
    }
}
