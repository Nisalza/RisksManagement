using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerQueriesBuilder.General
{
    public class Dictionaries
    {
        public enum ComparisonOperators : byte
        {
            EqualTo,
            GreaterThen,
            LessThen,
            GreaterThanOrEqualTo,
            LessThanOrEqualTo,
            NotEqualTo,
            All,
            In,
            Like
        }

        public Dictionary<ComparisonOperators, string> GetComparisonOperators()
        {
            return new Dictionary<ComparisonOperators, string>
            {
                {ComparisonOperators.EqualTo, " = "},
                {ComparisonOperators.GreaterThen, " > " },
                {ComparisonOperators.LessThen, " < " },
                {ComparisonOperators.GreaterThanOrEqualTo, " >= " },
                {ComparisonOperators.LessThanOrEqualTo, " <= " },
                {ComparisonOperators.NotEqualTo, " <> " },
                {ComparisonOperators.In, " in " },
                {ComparisonOperators.All, " all " },
                {ComparisonOperators.Like, " like " }
            };
        }

        public enum LogicOperators : byte
        {
            And,
            Or
        }

        public enum OrderBy
        {
            Asc,
            Desc
        }
    }
}
