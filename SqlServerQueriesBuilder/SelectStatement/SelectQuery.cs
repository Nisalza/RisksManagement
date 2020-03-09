using System.Linq;
using SqlServerQueriesBuilder.Exceptions;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.SelectStatement
{
    public class SelectQuery : ISelectQuery
    {
        public string TableName { get; set; }

        public string[] Columns { get; set; }

        public (Dictionaries.LogicOperators?, bool, ConditionClause)[] Where { get; set; }

        public string[] GroupBy { get; set; }

        public (Dictionaries.LogicOperators?, bool, ConditionClause)[] Having { get; set; }

        public (string, Dictionaries.OrderBy)[] OrderBy { get; set; }

        public bool Distinct { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(TableName)) 
                throw new NoRequiredDataException();

            string query = BuildSelect(Distinct);
            query += BuildFrom();
            query += BuildWhere();
            query += BuildGroupBy();
            query += BuildHaving();
            query += BuildOrderBy();

            return query;
        }

        private string BuildSelect(bool distinct = false)
        {
            if (IsNullData(Columns) || Columns.Length == 0)
                return $"select {(distinct ? "distinct " : "")}[{TableName}].* ";

            var b = new BuildersSupport();
            return
                $"select {(distinct ? "distinct " : "")}{b.ArrayToStringWithComma(TableName, Columns)} ";
        }

        private string BuildFrom() => $"from [{TableName}] ";

        private string BuildWhere()
        {
            if (IsNullData(Where)) return "";
            var b = new BuildersSupport();
            string res = b.BuildConditions(TableName, "where", Where);
            return res;
        }

        private string BuildGroupBy()
        {
            if (IsNullData(GroupBy)) return "";
            var b = new BuildersSupport();
            return $"group by {b.ArrayToStringWithComma(TableName, GroupBy)} ";
        }

        private string BuildHaving()
        {
            if (IsNullData(Having) || IsNullData(GroupBy)) return "";
            var b = new BuildersSupport();
            string res = b.BuildConditions(TableName, "having", Having);
            return res;
        }

        private string BuildOrderBy()
        {
            if (IsNullData(OrderBy)) return "";
            var b = new BuildersSupport();
            return $"order by {OrderBy.Aggregate("", (current, v) => current + $"[{TableName}].[{v.Item1}] {v.Item2}, ").TrimEnd(' ', ',')} ";
        }

        private bool IsNullData(object obj) => obj == null;
    }
}