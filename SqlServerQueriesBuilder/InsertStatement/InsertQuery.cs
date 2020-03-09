using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SqlServerQueriesBuilder.Exceptions;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.InsertStatement
{
    public class InsertQuery : IInsertQuery
    {
        public string TableName { get; set; }

        public string[] Columns { get; set; }

        public object[] Values { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(TableName) 
                || Columns == null 
                || Values == null 
                || Columns.Length != Values.Length) 
                throw new NoRequiredDataException();

            string res = BuildInsert();
            res += BuildColumns();
            res += BuildValues();
            return res;
        }

        private string BuildInsert()
        {
            return $"insert into [{TableName}] ";
        }

        private string BuildColumns()
        {
            var res = Columns.Aggregate("(", (current, t) => current + $"[{t}], ").TrimEnd(' ', ',');
            res += ") values ";
            return res;
        }

        private string BuildValues()
        {
            BuildersSupport b = new BuildersSupport();
            var res = $"({b.ArrayToStringWithComma(Values)})";
            return res;
        }
    }
}
