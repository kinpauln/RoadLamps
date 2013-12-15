using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadLamps.Winform
{
    public delegate void ServerEventHandler(object sender, ServerEventArgs args);
    public class TcpServer
    {
        public System.Net.Sockets.TcpListener listener;
        public event ServerEventHandler serverHandler;
        public void StartServer()
        {
            System.Text.Encoding enc = System.Text.Encoding.UTF8;
            string host = System.Net.Dns.GetHostName();
            int port = 9000;
            System.Net.IPAddress ipAdd = null;
            foreach (System.Net.IPAddress ipAddress in
                System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList)
            {
                if (!ipAddress.IsIPv6LinkLocal)
                    ipAdd = ipAddress;
            }
            if (null == ipAdd) return;
            listener = new System.Net.Sockets.TcpListener(ipAdd, port);
            listener = new System.Net.Sockets.TcpListener(new System.Net.IPEndPoint(ipAdd, port));
            try
            {
                listener.Start();
            }
            catch
            {
                return;
            }
            while (true)
            {
                System.Net.Sockets.TcpClient tcp = listener.AcceptTcpClient();
                System.Net.Sockets.NetworkStream ns = tcp.GetStream();
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                byte[] resBytes = new byte[256];
                int resSize;
                do
                {
                    resSize = ns.Read(resBytes, 0, resBytes.Length);
                    if (resSize == 0)
                    {
                        return;
                    }
                    ms.Write(resBytes, 0, resSize);
                } while (ns.DataAvailable);
                string resMsg = enc.GetString(ms.ToArray());
                serverHandler(this, new ServerEventArgs(this.GetRemoteIP(tcp), resMsg));
                ms.Close();
                string sendMsg = resMsg.Length.ToString() + "characters";
                byte[] sendBytes = enc.GetBytes(sendMsg);
                ns.Write(sendBytes, 0, sendBytes.Length);
                tcp.Close();
            }
        }
        public void StopServer()
        {
            listener.Stop();
        }
        #region Get Remote IP and Port Number。
        public string GetRemoteIP(System.Net.Sockets.TcpClient cln)
        {
            string ip = cln.Client.RemoteEndPoint.ToString().Split(':')[0];
            return ip;
        }
        public int GetRemotePort(System.Net.Sockets.TcpClient cln)
        {
            string temp = cln.Client.RemoteEndPoint.ToString().Split(':')[1];
            int port = System.Convert.ToInt32(temp);
            return port;
        }
        #endregion
    }

    public class ServerEventArgs : EventArgs
    {
        private string _ip;
        private string _resMsg;

        public string IP { get { return this._ip; } }
        public string ResMsg { get { return this._resMsg; } } 

        public ServerEventArgs(string ip, string resMsg) {
            this._ip = ip;
            this._resMsg = resMsg;
        }
    }
}
