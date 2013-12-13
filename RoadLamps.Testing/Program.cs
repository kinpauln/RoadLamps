using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading;
using System.ServiceModel;

namespace RoadLamps.Testing
{
    class Program
    {
        static void Main(string[] args)
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
