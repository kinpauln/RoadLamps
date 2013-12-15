using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoadLamps.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCallAdd_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            using (RoadLampsServiceClient client = new RoadLampsServiceClient("RoadLampsService"))
            { 
                try
                {
                    //double currResult = proxy.Add(x, y);
                    string rString = client.GetData(11);
                    MessageBox.Show(rString);
                }
                catch (Exception ex)
                {
                }
            }

            //using (ChannelFactory<RoadLamps.Contract.IRoadLampsService> channel = new ChannelFactory<RoadLamps.Contract.IRoadLampsService>("RoadLampsService"))
            //{
            //    RoadLamps.Contract.IRoadLampsService proxy = channel.CreateChannel();
            //    using (proxy as IDisposable)
            //    {
            //        double x = 100 * rd.NextDouble();
            //        double y = 100 * rd.NextDouble();
            //        try
            //        {
            //            //double currResult = proxy.Add(x, y);
            //            string rString = proxy.GetData(11);
            //            MessageBox.Show(rString);
            //        }
            //        catch (Exception ex)
            //        {
            //        }
            //    }
            //    //for (int i = 0; i < 5; i++)
            //    //{
            //    //    ThreadPool.QueueUserWorkItem(
            //    //        delegate
            //    //        {
            //    //            RoadLamps.Contract.IRoadLampsService proxy = channel.CreateChannel();
            //    //            using (proxy as IDisposable)
            //    //            {
            //    //                //double x = 100 * rd.NextDouble();
            //    //                //double y = 100 * rd.NextDouble();
            //    //                //double currResult = proxy.Add(x, y);
            //    //                string rString = proxy.GetData(i);
            //    //                this.Invoke(new Action(delegate { MessageBox.Show(rString); }));
            //    //                //MessageBox.Show(rString);
            //    //            }
            //    //        });
            //    //}
            //}
        }
    }
}
