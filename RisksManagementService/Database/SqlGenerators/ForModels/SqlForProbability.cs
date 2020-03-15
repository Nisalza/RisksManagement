using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;
using RisksManagementService.Database.Models;
using RisksManagementService.Database.Queries.Statements;
using SqlServerQueriesBuilder.General;

namespace RisksManagementService.Database.SqlGenerators.ForModels
{
    public class SqlForProbability : SqlForModel
    {
        public Probability SelectById(int pId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Probability));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(Probability), "Id");
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
            Probability result = ConvertAllFields(reader);
            return result;
        }

        public Probability[] SelectAllByType(ProbabilityType type)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Probability));

            var probabilityType = attributesSupport.DataDescriptionDatabaseColumn(typeof(Probability), "ProbabilityType");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = probabilityType,
                Values = new object[] { type.Id },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Probability[] result = ConvertAllFieldsArray(reader);
            return result;
        }

        private Probability ConvertAllFields(IDataReader reader)
        {
            Probability result = new Probability();
            SqlForProbabilityType sqlForProbabilityType = new SqlForProbabilityType();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private Probability[] ConvertAllFieldsArray(IDataReader reader)
        {
            List<Probability> result = new List<Probability>();
            while (reader.Read())
            {
                Probability t = GetOne(reader);
                result.Add(t);
            }

            return result.ToArray();
        }

        private Probability GetOne(IDataReader reader)
        {
            SqlForProbabilityType sqlForProbabilityType = new SqlForProbabilityType();
            int ptId = reader.GetInt32(3);
            Probability t = new Probability
            {
                Id = reader.GetInt32(0),
                Assessment = reader.GetFloat(1),
                Name = reader.GetString(2),
                ProbabilityType = sqlForProbabilityType.SelectById(ptId)
            };

            return t;
        }
    }
}