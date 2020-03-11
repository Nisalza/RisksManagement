using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RisksManagementHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(RisksManagementService.Service)))
            {
                host.Open();
                Console.ReadKey();
            }
        }
    }
}
