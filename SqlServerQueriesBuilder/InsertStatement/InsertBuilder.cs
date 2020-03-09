using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.InsertStatement
{
    public class InsertBuilder : IInsertBuilder
    {
        public IInsertQuery InsertQuery { get; private set;  }

        public InsertBuilder()
        {
            Reset();
        }

        public InsertBuilder(string tableName)
        {
            Reset();
            BuildTableName(tableName);
        }

        public void BuildTableName(string tableName)
        {
            InsertQuery.TableName = tableName;
        }

        public void BuildColumns(string[] columns)
        {
            InsertQuery.Columns = columns;
        }

        public void BuildValues(object[] values)
        {
            BuildersSupport b = new BuildersSupport();
            b.RealNumbersConverter(values);
            InsertQuery.Values = values;
        }

        public void Reset()
        {
            InsertQuery = new InsertQuery();
        }
    }
}
