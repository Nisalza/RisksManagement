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
        public IDeleteQuery DeleteQuery { get; private set; }

        public DeleteBuilder()
        {
            Reset();
        }

        public DeleteBuilder(string tn)
        {
            Reset();
            BuildTableName(tn);
        }

        public void BuildTableName(string tableName)
        {
            DeleteQuery.TableName = tableName;
        }

        public void BuildWhere((Dictionaries.LogicOperators?, bool, ConditionClause)[] @where)
        {
            CheckRealNumbers(where);
            DeleteQuery.Where = where;
        }

        public string BuildRequest()
        {
            return DeleteQuery.ToString();
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
