using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilder.UpdateStatement
{
    public class UpdateBuilder : IUpdateBuilder
    {
        public IUpdateQuery UpdateQuery { get; private set; }

        public UpdateBuilder()
        {
            Reset();
        }

        public UpdateBuilder(string tn)
        {
            Reset();
            BuildTableName(tn);
        }

        public void BuildTableName(string tableName)
        {
            UpdateQuery.TableName = tableName;
        }

        public void BuildValues((string, object)[] values)
        {
            CheckRealNumbers(values);
            UpdateQuery.Values = values;
        }

        public void BuildWhere((Dictionaries.LogicOperators?, bool, ConditionClause)[] where)
        {
            CheckRealNumbers(where);
            UpdateQuery.Where = where;
        }

        public string BuildRequest()
        {
            return UpdateQuery.ToString();
        }

        public void Reset()
        {
            UpdateQuery = new UpdateQuery();
        }

        private void CheckRealNumbers((string, object)[] values)
        {
            var b = new BuildersSupport();
            for (int i = 0; i < values.Length; ++i)
            {
                b.RealNumbersConverter(values[i].Item2);
            }
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
