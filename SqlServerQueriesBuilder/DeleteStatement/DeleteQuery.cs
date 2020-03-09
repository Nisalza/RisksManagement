using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerQueriesBuilder.Exceptions;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.DeleteStatement
{
    public class DeleteQuery : IDeleteQuery
    {
        public string TableName { get; set; }

        public (Dictionaries.LogicOperators?, bool, ConditionClause)[] Where { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(TableName)) throw new NoRequiredDataException();

            string res = BuildDelete();
            res += BuildWhere();
            return res;
        }

        private string BuildDelete()
        {
            return $"delete from [{TableName}] ";
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
