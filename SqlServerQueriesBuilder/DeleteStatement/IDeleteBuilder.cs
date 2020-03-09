using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.DeleteStatement
{
    public interface IDeleteBuilder
    {
        DeleteQuery DeleteQuery { get; }

        void SetTableName(string tableName);

        void SetWhere((Dictionaries.LogicOperators?, bool, ConditionClause)[] where);

        void Reset();
    }
}
