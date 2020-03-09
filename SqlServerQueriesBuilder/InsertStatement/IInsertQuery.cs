using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerQueriesBuilder.InsertStatement
{
    public interface IInsertQuery
    {
        string TableName { get; set; }

        string[] Columns { get; set; }

        object[] Values { get; set; }
    }
}
