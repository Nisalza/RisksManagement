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
    public class SqlForStrategy : SqlForModel
    {
        public Strategy SelectById(int strategyId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Strategy));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(Strategy), "Id");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = id,
                Values = new object[] { strategyId },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Strategy result = ConvertAllFields(reader);
            return result;
        }

        public Strategy[] SelectAllByType(StrategyType type)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Strategy));

            var strategyType = attributesSupport.DataDescriptionDatabaseColumn(typeof(Strategy), "StrategyType");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = strategyType,
                Values = new object[] { type.Id },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Strategy[] result = ConvertAllFieldsArray(reader);
            return result;
        }

        public Strategy[] SelectAll()
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Strategy));

            statement.SelectBuilder.BuildTableName(tableName);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Strategy[] result = ConvertAllFieldsArray(reader);
            return result;
        }

        private Strategy ConvertAllFields(IDataReader reader)
        {
            Strategy result = new Strategy();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private Strategy[] ConvertAllFieldsArray(IDataReader reader)
        {
            List<Strategy> result = new List<Strategy>();
            while (reader.Read())
            {
                var t = GetOne(reader);   
                result.Add(t);
            }

            return result.ToArray();
        }

        private Strategy GetOne(IDataReader reader)
        {
            SqlForStrategyType sqlForStrategyType = new SqlForStrategyType();
            int ptId = reader.GetInt32(2);
            Strategy t = new Strategy
            {
                Id = reader.GetInt32(0),
                Description = reader.GetString(1),
                StrategyType = sqlForStrategyType.SelectById(ptId)
            };

            return t;
        }
    }
}