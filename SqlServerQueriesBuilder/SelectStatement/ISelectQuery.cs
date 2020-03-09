using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.SelectStatement
{
    public interface ISelectQuery
    {
        string TableName { get; set; }

        string[] Columns { get; set; }

        (Dictionaries.LogicOperators?, bool, ConditionClause)[] Where { get; set; }

        string[] GroupBy { get; set; }

        (Dictionaries.LogicOperators?, bool, ConditionClause)[] Having { get; set; }

        (string, Dictionaries.OrderBy)[] OrderBy { get; set; }

        bool Distinct { get; set; }
    }
}
