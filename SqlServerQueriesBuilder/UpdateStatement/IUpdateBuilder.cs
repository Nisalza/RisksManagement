using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.UpdateStatement
{
    public interface IUpdateBuilder
    {
        UpdateQuery UpdateQuery { get; }

        void SetTableName(string tableName);

        void SetValues((string, object)[] values);

        void SetWhere((Dictionaries.LogicOperators?, bool, ConditionClause)[] where);

        void Reset();
    }
}
