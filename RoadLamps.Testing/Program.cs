using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading;
using System.ServiceModel;
using System.Net.Sockets;
using System.Net;

namespace RoadLamps.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            Test2();
        }


        private static void Test2() {
            TcpClient tcpClient = new TcpClient(); 
            
            string hostname = "kinpauln.oicp.net";
            //tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 13000);
            tcpClient.Connect(hostname, 9000);
            NetworkStream ns = tcpClient.GetStream();
            char b = 'a';
            byte[] bytes = new byte[1024];
            int recv;
            string mess;
            while (true)
            {
                mess = b.ToString();
                if (b > 3 + 'a')
                    mess = "bye";
                bytes = System.Text.Encoding.ASCII.GetBytes(mess);
                try
                {
                    ns.Write(bytes, 0, bytes.Length);
                }
                catch
                {
                    Console.WriteLine("missing");
                    break;
                }
                bytes = new byte[1024];
                try
                {
                    if ((recv = ns.Read(bytes, 0, 1024)) == 0)
                    {
                        Console.WriteLine("disconnected");
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("missing");
                    break;
                }
                mess = System.Text.Encoding.ASCII.GetString(bytes, 0, recv);
                Console.WriteLine(mess);
                Thread.Sleep(1000);
                if (b > 3 + 'a')
                    break;
                ++b;
            }
            ns.Close();
            tcpClient.Close();
        }
        private static void Test1()
        {
            try
            {
                Random rd = new Random();
                using (ChannelFactory<RoadLamps.Service.Old.IEquipmentService> channel = new ChannelFactory<RoadLamps.Service.Old.IEquipmentService>("CalculatorService"))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        ThreadPool.QueueUserWorkItem(
                            delegate
                            {
                                RoadLamps.Service.Old.IEquipmentService ic = channel.CreateChannel();
                                using (ic as IDisposable)
                                {
                                    double x = 100 * rd.NextDouble();
                                    double y = 100 * rd.NextDouble();
                                    ic.Add(x, y);
                                    Console.WriteLine("第" + i.ToString() + "次请求已发送...");
                                }

                            });
                    }
                    RoadLamps.Service.Old.IEquipmentService ic2 = channel.CreateChannel();
                    ic2.CreateFile();
                    Console.WriteLine("请求发送完毕...");
                    Console.Read();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.Read();
            }
        }
    }
}
