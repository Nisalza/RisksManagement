using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using RisksManagementClient.ServiceRisksManagement;

namespace RisksManagementClient
{
    public class SingletonClient
    {
        private static SingletonClient _instance;

        public ServiceClient Client { get; private set; }

        public static SingletonClient GetInstance(IServiceCallback cb)
        {
            return _instance ?? (_instance = new SingletonClient(cb));
        }

        public static SingletonClient GetInstance()
        {
            return _instance;
        }

        private SingletonClient(IServiceCallback cb)
        {
            Client = new ServiceClient(new InstanceContext(cb));
        }
    }
}
