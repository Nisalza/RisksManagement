using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisksManagementClient.Strategies
{
    public interface IStrategy
    {
        bool Execute(object dbModel);
    }
}
