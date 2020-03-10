using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerQueriesBuilder
{
    public interface IBuilder
    {
        string BuildRequest();

        void Reset();
    }
}
