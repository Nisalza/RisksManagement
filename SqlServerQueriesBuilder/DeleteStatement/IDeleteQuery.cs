using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.DeleteStatement
{
    public interface IDeleteQuery
    {
        string TableName { get; set; }

        (Dictionaries.LogicOperators?, bool, ConditionClause)[] Where { get; set; }
    }
}
