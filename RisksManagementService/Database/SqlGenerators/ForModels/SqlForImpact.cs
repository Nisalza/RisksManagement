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
    public class SqlForImpact : SqlForModel
    {
        public Impact SelectById(int impactId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Impact));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(Impact), "Id");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = id,
                Values = new object[] { impactId },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Impact result = ConvertAllFields(reader);
            return result;
        }

        public Impact[] SelectByType(ImpactType type)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Probability));

            var impactType = attributesSupport.DataDescriptionDatabaseColumn(typeof(Probability), "ImpactType");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = impactType,
                Values = new object[] { type.Id },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Impact[] result = ConvertAllFieldsArray(reader);
            return result;
        }

        private Impact ConvertAllFields(IDataReader reader)
        {
            Impact result = new Impact();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private Impact[] ConvertAllFieldsArray(IDataReader reader)
        {
            List<Impact> result = new List<Impact>();
            while (reader.Read())
            {
                var t = GetOne(reader);
                result.Add(t);
            }

            return result.ToArray();
        }

        private Impact GetOne(IDataReader reader)
        {
            SqlForImpactType sqlForProbabilityType = new SqlForImpactType();
            int itId = reader.GetInt32(3);
            Impact t = new Impact
            {
                Id = reader.GetInt32(0),
                Assessment = reader.GetFloat(1),
                Name = reader.GetString(2),
                ImpactType = sqlForProbabilityType.SelectById(itId)
            };

            return t;
        }
    }
}