using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RisksManagementClient.ServiceRisksManagement;

namespace RisksManagementClient.Strategies.StrategyStrategies
{
    public class UpdateStrategyStrategy : IStrategy
    {
        public bool Execute(object dbModel)
        {
            SingletonClient client = SingletonClient.GetInstance();
            Strategy strategy = dbModel as Strategy;
            bool result = client.Client.UpdateStrategy(strategy);
            return result;
        }
    }
}
