using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerQueriesBuilder.Exceptions;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.SelectClause
{
    public class SelectQuery
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
            if (IsNullData(TableName) || IsNullData(Columns) || Columns.Length == 0)
            {
                throw new NoRequiredDataException();
            }

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
            var b = new Builders();
            return
                $"select {(distinct ? "distinct " : "")}{b.ArrayToStringWithComma(TableName, Columns)} ";
        }

        private string BuildFrom() => $"from [{TableName}] ";

        private string BuildWhere()
        {
            if (IsNullData(Where)) return "";
            var comp = new Dictionaries().GetComparisonOperators();
            var res = "where";
            var b = new Builders();
            foreach (var (logic, not, condition) in Where)
            {
                res += $"{logic?.ToString()} {(not ? "not " : "")}[{TableName}].[{condition.ColumnName}]{comp[condition.Operator]}{b.BuildComparison(condition.Operator, condition.Values)} ";
            }
            return res;
        }

        private string BuildGroupBy()
        {
            if (IsNullData(GroupBy)) return "";
            var b = new Builders();
            return $"group by {b.ArrayToStringWithComma(TableName, GroupBy)} ";
        }

        private string BuildHaving()
        {
            if (IsNullData(Having) || IsNullData(GroupBy)) return "";
            var comp = new Dictionaries().GetComparisonOperators();
            var res = "having";
            var b = new Builders();
            foreach (var (logic, not, condition) in Having)
            {
                res += $"{logic?.ToString()} {(not ? "not " : "")}[{TableName}].[{condition.ColumnName}]{comp[condition.Operator]}{b.BuildComparison(condition.Operator, condition.Values)} ";
            }
            return res;
        }

        private string BuildOrderBy()
        {
            if (IsNullData(OrderBy)) return "";
            var b = new Builders();
            return $"order by {OrderBy.Aggregate("", (current, v) => current + $"[{TableName}].[{v.Item1}] {v.Item2}, ").TrimEnd(' ', ',')} ";
        }

        private bool IsNullData(object obj) => obj == null;
    }
}