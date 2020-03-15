using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;
using RisksManagementService.Database.Models;
using RisksManagementService.Database.Queries.Statements;
using SqlServerQueriesBuilder.General;
using Environment = RisksManagementService.Database.Models.Environment;

namespace RisksManagementService.Database.SqlGenerators.ForModels
{
    public class SqlForEnvironment : SqlForModel
    {
        public Environment SelectById(int pId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Environment));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(Environment), "Id");
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
            Environment result = ConvertAllFields(reader);
            return result;
        }

        public Environment[] SelectAllByType(Risk risk)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Environment));

            var riskDbName = attributesSupport.DataDescriptionDatabaseColumn(typeof(Environment), "Risk");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = riskDbName,
                Values = new object[] { risk.Id },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Environment[] result = ConvertAllFieldsArray(reader);
            return result;
        }

        private Environment ConvertAllFields(IDataReader reader)
        {
            Environment result = new Environment();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private Environment[] ConvertAllFieldsArray(IDataReader reader)
        {
            List<Environment> result = new List<Environment>();
            while (reader.Read())
            {
                var t = GetOne(reader);
                result.Add(t);
            }

            return result.ToArray();
        }

        private Environment GetOne(IDataReader reader)
        {
            SqlForRisk sqlForRisk = new SqlForRisk();
            int riskId = reader.GetInt32(7);
            SqlGetData sqlGetData = new SqlGetData();
            Environment t = new Environment
            {
                Id = reader.GetInt32(0),
                Address = sqlGetData.GetNullableString(reader, 1),
                Application = sqlGetData.GetNullableString(reader, 2),
                Process = sqlGetData.GetNullableString(reader, 3),
                Grade = sqlGetData.GetNullableString(reader, 4),
                Description = sqlGetData.GetNullableString(reader, 5),
                Date = reader.GetDateTime(6),
                Risk = sqlForRisk.SelectById(riskId)
            };

            return t;
        }
    }
}