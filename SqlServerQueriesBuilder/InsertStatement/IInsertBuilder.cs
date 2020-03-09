using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerQueriesBuilder.InsertStatement
{
    public interface IInsertBuilder
    {
        IInsertQuery InsertQuery { get; }

        void BuildTableName(string tableName);

        void BuildColumns(string[] columns);

        void BuildValues(object[] values);

        void Reset();
    }
}
