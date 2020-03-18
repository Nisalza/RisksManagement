using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisksManagementClient.Strategies
{
    public interface IContext
    {
        bool Result { get; set; }

        void SetStrategy(IStrategy strategy);

        void ExecuteStrategy(object dbModel);
    }
}
