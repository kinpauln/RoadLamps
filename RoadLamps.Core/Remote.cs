using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadLamps.Core
{
    public class Remote
    {
        #region Get Remote IP and Port Number。
        public static string GetRemoteIP(System.Net.Sockets.TcpClient cln)
        {
            string ip = cln.Client.RemoteEndPoint.ToString().Split(':')[0];
            return ip;
        }
        public static int GetRemotePort(System.Net.Sockets.TcpClient cln)
        {
            string temp = cln.Client.RemoteEndPoint.ToString().Split(':')[1];
            int port = System.Convert.ToInt32(temp);
            return port;
        }
        #endregion
    }
}
