using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerQueriesBuilder.General
{
    public class Builders
    {
        //todo Лучше бы сделать перевод для вещественных чисел с ToString(CultureInfo.InvariantCulture) чтобы база не ругалась
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
    }
}
