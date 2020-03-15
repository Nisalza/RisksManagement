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
    public class SqlForRelevance : SqlForModel
    {
        public Relevance SelectById(int ptId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Relevance));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(Relevance), "Id");
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
            Relevance result = ConvertAllFields(reader);
            return result;
        }

        public Relevance[] SelectAll()
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Relevance));

            statement.SelectBuilder.BuildTableName(tableName);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Relevance[] result = ConvertAllFieldsArray(reader);
            return result;
        }

        private Relevance ConvertAllFields(IDataReader reader)
        {
            Relevance result = new Relevance();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private Relevance[] ConvertAllFieldsArray(IDataReader reader)
        {
            List<Relevance> result = new List<Relevance>();
            while (reader.Read())
            {
                Relevance t = GetOne(reader);
                result.Add(t);
            }

            return result.ToArray();
        }

        private Relevance GetOne(IDataReader reader)
        {
            Relevance t = new Relevance
            {
                Id = reader.GetInt32(0),
                Assessment = reader.GetFloat(1),
                Name = reader.GetString(2)
            };

            return t;
        }
    }
}