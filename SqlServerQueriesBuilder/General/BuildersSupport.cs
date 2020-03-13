using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerQueriesBuilder.General
{
    public class BuildersSupport
    {
        public string BuildComparison(Dictionaries.ComparisonOperators co, object[] values)
        {
            switch (co)
            {
                case Dictionaries.ComparisonOperators.In:
                case Dictionaries.ComparisonOperators.All:
                    return $"({ArrayToStringWithComma(values)})";
                default:
                    return $"\'{values.FirstOrDefault()}\'";
            }
        }

        public string ArrayToStringWithComma(object[] values)
        {
            return values.Aggregate("", (current, v) => current + $"\'{v}\', ").TrimEnd(' ', ',');
        }

        public string ArrayToStringWithComma(string[] values)
        {
            return values.Aggregate("", (current, v) => current + $"\'{v}\', ").TrimEnd(' ', ',');
        }

        public string ArrayToStringWithComma(string tableName, string[] values)
        {
            return values.Aggregate("", (current, v) => current + $"[{tableName}].[{v}], ").TrimEnd(' ', ',');
        }

        public object RealNumbersConverter(object item)
        {
            if (item is float f)
            {
                item = f.ToString(CultureInfo.InvariantCulture);
            }

            return item;
        }

        public object[] RealNumbersConverter(object[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] is float)
                {
                    array[i] = ((float)array[i]).ToString(CultureInfo.InvariantCulture);
                }
            }

            return array;
        }

        public string BuildConditions(string tableName, string clause, (Dictionaries.LogicOperators?, bool, ConditionClause)[] data)
        {
            var comp = new Dictionaries().GetComparisonOperators();
            var res = clause;
            var b = new BuildersSupport();
            foreach (var (logic, not, condition) in data)
            {
                res += $"{logic?.ToString()} {(not ? "not " : "")}[{tableName}].[{condition.ColumnName}]{comp[condition.Operator]}{b.BuildComparison(condition.Operator, condition.Values)} ";
            }
            return res;
        } 
    }
}
