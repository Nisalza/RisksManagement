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
    public class SqlForRiskCause : SqlForModel
    {
        public RiskCause SelectById(int ptId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(RiskCause));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(RiskCause), "Id");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = id,
                Values = new object[] { ptId },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            RiskCause result = ConvertAllFields(reader);
            return result;
        }

        public RiskCause[] SelectAll()
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(RiskCause));

            statement.SelectBuilder.BuildTableName(tableName);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            RiskCause[] result = ConvertAllFieldsArray(reader);
            return result;
        }

        private RiskCause ConvertAllFields(IDataReader reader)
        {
            RiskCause result = new RiskCause();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private RiskCause[] ConvertAllFieldsArray(IDataReader reader)
        {
            List<RiskCause> result = new List<RiskCause>();
            while (reader.Read())
            {
                RiskCause t = GetOne(reader);
                result.Add(t);
            }

            return result.ToArray();
        }

        private RiskCause GetOne(IDataReader reader)
        {
            SqlGetData sqlGetData = new SqlGetData();
            RiskCause t = new RiskCause
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = sqlGetData.GetNullableString(reader, 2)
            };

            return t;
        }
    }
}