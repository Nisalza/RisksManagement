using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerQueriesBuilder.Exceptions;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.UpdateStatement
{
    public class UpdateQuery
    {
        public string TableName { get; set; }

        public (string, object)[] Values { get; set; }

        public (Dictionaries.LogicOperators?, bool, ConditionClause)[] Where { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(TableName) || Values == null || Values.Length == 0)
                throw new NoRequiredDataException();

            string res = BuildUpdate();
            res += BuildSet();
            res += BuildWhere();
            return res;
        }

        private string BuildUpdate()
        {
            return $"update [{TableName}] ";
        }

        private string BuildSet()
        {
            return
                $"{Values.Aggregate("set ", (current, t) => current + $"[{TableName}].[{t.Item1}] = \'{t.Item2}\', ").TrimEnd(' ', ',')} ";
        }

        private string BuildWhere()
        {
            if (Where == null) return "";
            var b = new BuildersSupport();
            var res = b.BuildConditions(TableName, "where", Where);
            return res;
        }
    }
}
