using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.SelectStatement
{
    public class SelectBuilder : ISelectBuilder
    {
        public SelectQuery SelectQuery { get; private set; }

        public SelectBuilder()
        {
            Reset();
        }

        public SelectBuilder(string name, string[] cols)
        {
            Reset();
            BuildTableName(name);
            BuildColumns(cols);
        }

        public void BuildTableName(string tableName)
        {
            SelectQuery.TableName = tableName;
        }

        public void BuildColumns(string[] cols)
        {
            SelectQuery.Columns = cols;
        }

        public void BuildWhere((Dictionaries.LogicOperators?, bool, ConditionClause)[] where)
        {
            CheckRealNumbers(where);
            SelectQuery.Where = where;
        }

        public void BuildGroupBy(string[] groupBy)
        {
            SelectQuery.GroupBy = groupBy;
        }

        public void BuildHaving((Dictionaries.LogicOperators?, bool, ConditionClause)[] having)
        {
            CheckRealNumbers(having);
            SelectQuery.Having = having;
        }

        public void BuildOrderBy((string, Dictionaries.OrderBy)[] orderBy)
        {
            SelectQuery.OrderBy = orderBy;
        }

        public void BuildDistinct(bool distinct)
        {
            SelectQuery.Distinct = distinct;
        }

        public void Reset()
        {
            SelectQuery = new SelectQuery();
        }

        private void CheckRealNumbers((Dictionaries.LogicOperators?, bool, ConditionClause)[] values)
        {
            var b = new BuildersSupport();
            for (int i = 0; i < values.Length; ++i)
            {
                b.RealNumbersConverter(values[i].Item3.Values);
            }
        }
    }
}
