namespace SqlServerQueriesBuilder.General
{
    public class ConditionClause
    {
        public string ColumnName { get; set; }

        public Dictionaries.ComparisonOperators Operator { get; set; }

        public object[] Values { get; set; }
    }
}
