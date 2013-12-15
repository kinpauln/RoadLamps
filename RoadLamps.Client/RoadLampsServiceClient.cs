using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using RoadLamps.Contract;
using System.ServiceModel.Channels;

namespace RoadLamps.Client
{
    public partial class RoadLampsServiceClient : ClientBase<IRoadLampsService>, IRoadLampsService
    {
        #region Constructors
        public RoadLampsServiceClient()
            : base()
        { }

        public RoadLampsServiceClient(string endpointConfigurationName)
            : base(endpointConfigurationName)
        { }

        public RoadLampsServiceClient(Binding binding, EndpointAddress address)
            : base(binding, address)
        { }

        public RoadLampsServiceClient(InstanceContext callbackInstance)
            : base(callbackInstance)
        { } 
        #endregion

        #region IGeneralCalculator Members

        public string GetData(int value)
        {
            return this.Channel.GetData(value);
        }        

        public double Add(double x, double y)
        {
            return this.Channel.Add(x, y);
        }

        public bool CreateFile() {
            return this.Channel.CreateFile();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            return this.Channel.GetDataUsingDataContract(composite);
        }

        #endregion   
    }
}
