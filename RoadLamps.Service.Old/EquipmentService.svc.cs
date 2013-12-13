using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Channels;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using RoadLamps.Service.Old;

namespace RoadLamps.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EquipmentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EquipmentService.svc or EquipmentService.svc.cs at the Solution Explorer and start debugging.
     [ServiceBehavior(UseSynchronizationContext = false)]
    public class EquipmentService : IEquipmentService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        #region ICalculator 成员

        public static ListView DisplayPanel { get; set; }

        public static SynchronizationContext synContext{ get; set; }

        public double Add(double x, double y)
        {
            DateTime calculationtime = System.DateTime.Now;
            string threadID = Thread.CurrentThread.ManagedThreadId.ToString();
            double result = x + y;
            object remoteObject;
            OperationContext.Current.IncomingMessageProperties.TryGetValue(RemoteEndpointMessageProperty.Name, out remoteObject);
            string ipAddress = (remoteObject as RemoteEndpointMessageProperty).Address;
            synContext.Post(
            delegate
            {
                ListViewItem li = new ListViewItem(new string[] { string.Format("the result is{2} when x={0} and y={1}", x, y, result), ipAddress, calculationtime.ToString("hh:MM:ss"), threadID });
                DisplayPanel.Items.Add(li);
            }, null);
            Thread.Sleep(5000);
            return x + y;
        }

        #endregion

        public bool CreateFile() {
            string file = @"d:\efg.txt";
            string content = "hahhaha";
            if (File.Exists(file))
            {
                MessageBox.Show("存在此文件!");
            }
            else
            {
                FileStream myFs = new FileStream(file, FileMode.Create);
                StreamWriter mySw = new StreamWriter(myFs);
                mySw.Write(content);
                mySw.Close();
                myFs.Close();
                MessageBox.Show("写入成功");
            }
            return true;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}