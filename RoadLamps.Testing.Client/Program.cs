using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoadLamps.Testing.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 13001);
            NetworkStream ns = tcpClient.GetStream();
            char b = 'a';
            byte[] bytes = new byte[1024];
            int recv;
            string mess;
            while (true)
            {
                #region send data
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
                #endregion

                #region receive data
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
                #endregion

                Thread.Sleep(1000);
                if (b > 3 + 'a')
                    break;
                ++b;
            }
            ns.Close();
            tcpClient.Close();  
        }
    }
}
