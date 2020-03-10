using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.SelectStatement
{
    public interface ISelectBuilder : IBuilder
    {
        ISelectQuery SelectQuery { get; }

        void BuildTableName(string tableName);

        void BuildColumns(string[] cols);

        void BuildWhere((Dictionaries.LogicOperators?, bool, ConditionClause)[] where);

        void BuildGroupBy(string[] groupBy);

        void BuildHaving((Dictionaries.LogicOperators?, bool, ConditionClause)[] having);

        void BuildOrderBy((string, Dictionaries.OrderBy)[] orderBy);

        void BuildDistinct(bool distinct);
    }
}
