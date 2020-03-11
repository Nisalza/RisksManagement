using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RisksManagementClient.ServiceRisksManagement;

namespace RisksManagementClient
{
    public class SingletonHost
    {
        private static SingletonHost _instance;

        public IService Host { get; private set; }

        public static SingletonHost GetInstance()
        {
            return _instance ?? (_instance = new SingletonHost());
        }

        private SingletonHost()
        {
            //Host = new ServiceClient();
        }
    }
}
