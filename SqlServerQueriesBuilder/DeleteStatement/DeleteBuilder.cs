using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.DeleteStatement
{
    public class DeleteBuilder : IDeleteBuilder
    {
        public DeleteQuery DeleteQuery { get; private set; }

        public DeleteBuilder()
        {
            Reset();
        }

        public DeleteBuilder(string tn)
        {
            Reset();
            DeleteQuery.TableName = tn;
        }

        public void SetTableName(string tableName)
        {
            DeleteQuery.TableName = tableName;
        }

        public void SetWhere((Dictionaries.LogicOperators?, bool, ConditionClause)[] @where)
        {
            CheckRealNumbers(where);
            DeleteQuery.Where = where;
        }

        public void Reset()
        {
            DeleteQuery = new DeleteQuery();
        }

        private void CheckRealNumbers((Dictionaries.LogicOperators?, bool, ConditionClause)[] values)
        {
            var b = new BuildersSupport();
            for (int i = 0; i < values.Length; ++i)
            {
                b.RealNumbersConverter(values[i].Item3.Values);
            }
        }
    }
}
