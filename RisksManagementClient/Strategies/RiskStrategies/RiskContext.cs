using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisksManagementClient.Strategies.RiskStrategies
{
    public class RiskContext : IContext
    {
        private IStrategy _strategy;

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public bool ExecuteStrategy(object dbModel)
        {
            if (_strategy == null) return false;

            bool ok = _strategy.Execute(dbModel);
            return ok;
        }
    }
}
