﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisksManagementClient.Strategies.RiskStrategies
{
    public class RiskContext : IContext
    {
        private IStrategy _strategy;

        public bool Result { get; set; }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteStrategy(object dbModel)
        {
            if (_strategy == null)
            {
                Result = false;
                return;
            }

            Result = _strategy.Execute(dbModel);
        }
    }
}
