using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.UpdateStatement
{
    public interface IUpdateBuilder : IBuilder
    {
        IUpdateQuery UpdateQuery { get; }

        void BuildTableName(string tableName);

        void BuildValues((string, object)[] values);

        void BuildWhere((Dictionaries.LogicOperators?, bool, ConditionClause)[] where);
    }
}
