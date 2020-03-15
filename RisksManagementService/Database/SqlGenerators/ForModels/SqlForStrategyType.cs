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
    public class SqlForStrategyType : SqlForModel
    {
        public StrategyType SelectById(int stId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(StrategyType));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(StrategyType), "Id");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = id,
                Values = new object[] { stId },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            StrategyType result = ConvertAllFields(reader);
            return result;
        }

        public StrategyType[] SelectAll()
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(StrategyType));

            statement.SelectBuilder.BuildTableName(tableName);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            StrategyType[] result = ConvertAllFieldsArray(reader);
            return result;
        }

        private StrategyType ConvertAllFields(IDataReader reader)
        {
            StrategyType result = new StrategyType();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private StrategyType[] ConvertAllFieldsArray(IDataReader reader)
        {
            List<StrategyType> result = new List<StrategyType>();
            while (reader.Read())
            {
                var t = GetOne(reader);
                result.Add(t);
            }

            return result.ToArray();
        }

        private StrategyType GetOne(IDataReader reader)
        {
            SqlGetData sqlGetData = new SqlGetData();
            StrategyType t = new StrategyType
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = sqlGetData.GetNullableString(reader, 2)
            };

            return t;
        }
    }
}