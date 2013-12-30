using RoadLamps.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoadLamps.Hosting
{
    class MyClient
    {
        TcpClient m_tcpClient;
        Form1 _form;

        public MyClient(TcpClient tc)
        {
            m_tcpClient = tc;
        }

        public MyClient(TcpClient tc, Form1 form)
            : this(tc)
        {
            _form = form;
        }

        public void Communicate()
        {
            NetworkStream ns = m_tcpClient.GetStream();
            int recv;
            string mess;
            while (true)
            {
                string msg = string.Empty;
                byte[] bytes = new byte[1024];
                try
                {
                    if ((recv = ns.Read(bytes, 0, 1024)) == 0)
                    {
                        //Console.WriteLine("disconnected");
                        msg = "disconnected";
                        break;
                    }
                }
                catch
                {
                    //Console.WriteLine("missing");
                    msg = "missing";
                    break;
                }
                mess = System.Text.Encoding.ASCII.GetString(bytes, 0, recv);
                string ipaddress = Remote.GetRemoteIP(m_tcpClient);
                int port = Remote.GetRemotePort(m_tcpClient);
                msg = m_tcpClient.Client.AddressFamily.ToString() + "::" + mess;
                msg = string.Format("{0}:{1}-----{2}",ipaddress, port, mess);

                //IEnumerable<ListView> lvs = GetAllControls<ListView>(_form);
                ListView lvobj = (ListView)_form.Controls.Cast<Control>().Where(c => c.Name.Equals("lvListeningResult")).FirstOrDefault();

                lvobj.Invoke(new Action(() =>
                {
                    lvobj.Items.Add(new ListViewItem(msg));
                }));

                //bytes = System.Text.Encoding.ASCII.GetBytes(mess.ToUpper());
                //try
                //{
                //    ns.Write(bytes, 0, bytes.Length);
                //}
                //catch
                //{
                //    Console.WriteLine("missing");
                //    break;
                //}
            }
            ns.Close();
            m_tcpClient.Close();
        }

        public IEnumerable<T> GetAllControls<T>(Control container) where T : Control
        {
            var controls = container.Controls.Cast<T>();

            return controls.SelectMany(ctrl => GetAllControls<T>(ctrl))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == typeof(T));
        }
    }
}
