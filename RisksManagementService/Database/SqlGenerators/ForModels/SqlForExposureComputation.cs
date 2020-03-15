using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using RisksManagementService.Attributes;
using RisksManagementService.Database.Models;
using RisksManagementService.Database.Queries.Statements;
using SqlServerQueriesBuilder.General;

namespace RisksManagementService.Database.SqlGenerators.ForModels
{
    public class SqlForExposureComputation : SqlForModel
    {
        public ExposureComputation SelectById(int ecId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(ExposureComputation));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(ExposureComputation), "Id");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = id,
                Values = new object[] { ecId },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            ExposureComputation result = ConvertAllFields(reader);
            return result;
        }
        
        private ExposureComputation ConvertAllFields(IDataReader reader)
        {
            ExposureComputation result = new ExposureComputation();
            SqlForProbabilityType sqlForProbabilityType = new SqlForProbabilityType();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private ExposureComputation[] ConvertAllFieldsArray(IDataReader reader)
        {
            List<ExposureComputation> result = new List<ExposureComputation>();
            while (reader.Read())
            {
                var t = GetOne(reader);
                result.Add(t);
            }

            return result.ToArray();
        }

        private ExposureComputation GetOne(IDataReader reader)
        {
            ExposureComputation t = new ExposureComputation
            {
                Id = reader.GetInt32(0),
                Formula = reader.GetString(1)
            };

            return t;
        }
    }
}