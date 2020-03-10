using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.DeleteStatement
{
    public interface IDeleteBuilder : IBuilder
    {
        IDeleteQuery DeleteQuery { get; }

        void BuildTableName(string tableName);

        void BuildWhere((Dictionaries.LogicOperators?, bool, ConditionClause)[] where);
    }
}
