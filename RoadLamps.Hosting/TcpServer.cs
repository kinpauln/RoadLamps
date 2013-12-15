using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoadLamps.Hosting
{
    public partial class TcpServer
    {

        public TcpServer() { }

        public void adfsdl() {
            IPAddress ipAddress = IPAddress.Any;
            TcpListener tcpListener = new TcpListener(ipAddress, 13000);
            tcpListener.Start();

            bool done = false;
            while (!done)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                MyClient newClient = new MyClient(tcpClient);
                Thread t = new Thread(new ThreadStart(newClient.Communicate));
                t.Start();
            }  
        }
    }
}
