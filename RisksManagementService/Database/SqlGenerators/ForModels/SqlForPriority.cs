using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;
using RisksManagementService.Database.Models;
using RisksManagementService.Database.Queries.Statements;
using SqlServerQueriesBuilder.General;

namespace RisksManagementService.Database.SqlGenerators.ForModels
{
    public class SqlForPriority : SqlForModel
    {
        public Priority SelectById(int pId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Priority));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(Priority), "Id");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = id,
                Values = new object[] { pId },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Priority result = ConvertAllFields(reader);
            return result;
        }

        public Priority[] SelectAll()
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Priority));

            statement.SelectBuilder.BuildTableName(tableName);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Priority[] result = ConvertAllFieldsArray(reader);
            return result;
        }

        private Priority ConvertAllFields(IDataReader reader)
        {
            Priority result = new Priority();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private Priority[] ConvertAllFieldsArray(IDataReader reader)
        {
            List<Priority> result = new List<Priority>();
            while (reader.Read())
            {
                var t = GetOne(reader);
                result.Add(t);
            }

            return result.ToArray();
        }

        private Priority GetOne(IDataReader reader)
        {
            Priority t = new Priority
            {
                Id = reader.GetInt32(0),
                Assessment = reader.GetFloat(1),
                Name = reader.GetString(2)
            };

            return t;
        }
    }
}