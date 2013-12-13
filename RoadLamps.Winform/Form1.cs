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
using System.Threading;
using System.Diagnostics;
using System.IO;
using RoadLamps.Service;

namespace RoadLamps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EquipmentService.DisplayPanel = this.listView1;
            EquipmentService.synContext = SynchronizationContext.Current;
            _servicehost = new ServiceHost(typeof(EquipmentService));
            this._servicehost.Open();
        }
        private ServiceHost _servicehost = null;
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            IDisposable disposible = this._servicehost as IDisposable;
            if (disposible != null)
                disposible.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //EquipmentServiceClient client = new EquipmentServiceClient();
            //string testString = client.GetData(3);
            //MessageBox.Show(testString);
            //// 使用 "client" 变量在服务上调用操作。

            //// 始终关闭客户端。
            //client.Close();

            //string info = startcmd("ipconfig.exe");
            //startcmd1111("services.msc");
            //richTextBox1.AppendText(info);

            CreateFile();
        }

        public bool CreateFile()
        {
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

        public static void startcmd1111(string command)
        {
            try
            {

                Process cmd = new Process();
                cmd.StartInfo.FileName = command;

                cmd.StartInfo.UseShellExecute = false;

                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;

                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                cmd.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static string startcmd(string command)
        {
            string output = "";
            try
            {

                Process cmd = new Process();
                cmd.StartInfo.FileName = command;

                cmd.StartInfo.UseShellExecute = false;

                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;

                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                cmd.Start();

                output = cmd.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                cmd.WaitForExit();
                cmd.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return output;
        }

        public static string startcmd(string command, string argument)
        {
            string output = "";
            try
            {
                Process cmd = new Process();

                cmd.StartInfo.FileName = command;
                cmd.StartInfo.Arguments = argument;

                cmd.StartInfo.UseShellExecute = false;

                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;

                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                cmd.Start();

                output = cmd.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                cmd.WaitForExit();
                cmd.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return output;
        }
    }
}
