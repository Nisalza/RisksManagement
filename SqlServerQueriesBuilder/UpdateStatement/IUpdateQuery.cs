using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.UpdateStatement
{
    public interface IUpdateQuery
    {
        string TableName { get; set; }

        (string, object)[] Values { get; set; }

        (Dictionaries.LogicOperators?, bool, ConditionClause)[] Where { get; set; }
    }
}
