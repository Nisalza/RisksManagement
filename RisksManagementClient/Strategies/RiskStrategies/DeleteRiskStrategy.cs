using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RisksManagementClient.ServiceRisksManagement;

namespace RisksManagementClient.Strategies.RiskStrategies
{
    public class DeleteRiskStrategy : IStrategy
    {
        public bool Execute(object dbModel)
        {
            SingletonClient client = SingletonClient.GetInstance();
            Risk risk = dbModel as Risk;
            bool result = client.Client.DeleteRisk(risk);
            return result;
        }
    }
}
