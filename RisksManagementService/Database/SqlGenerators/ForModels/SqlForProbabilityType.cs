using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Prism.Common;
using RisksManagementService.Attributes;
using RisksManagementService.Database.Models;
using RisksManagementService.Database.Queries.Statements;
using SqlServerQueriesBuilder.General;

namespace RisksManagementService.Database.SqlGenerators.ForModels
{
    public class SqlForProbabilityType : SqlForModel
    {
        public ProbabilityType SelectById(int ptId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(ProbabilityType));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(ProbabilityType), "Id");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = id,
                Values = new object[] {ptId},
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] {(null, false, c1)};

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            ProbabilityType result = ConvertAllFields(reader);
            return result;
        }

        public ProbabilityType[] SelectAll()
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(ProbabilityType));

            statement.SelectBuilder.BuildTableName(tableName);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            ProbabilityType[] result = ConvertAllFieldsArray(reader);
            return result;
        }

        private ProbabilityType ConvertAllFields(IDataReader reader)
        {
            ProbabilityType result = new ProbabilityType();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private ProbabilityType[] ConvertAllFieldsArray(IDataReader reader)
        {
            List<ProbabilityType> result = new List<ProbabilityType>();
            while (reader.Read())
            {
                ProbabilityType t = GetOne(reader);
                result.Add(t);
            }

            return result.ToArray();
        }

        private ProbabilityType GetOne(IDataReader reader)
        {
            ProbabilityType t = new ProbabilityType
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            };

            return t;
        }
    }
}