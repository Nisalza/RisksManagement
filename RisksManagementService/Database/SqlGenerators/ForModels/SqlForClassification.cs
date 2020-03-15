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
    public class SqlForClassification : SqlForModel
    {
        public Classification SelectById(int clsfId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Classification));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(Classification), "Id");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = id,
                Values = new object[] { clsfId },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Classification result = ConvertAllFields(reader);
            return result;
        }

        public Classification SelectBySuperclass(Classification superclass)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Classification));

            var superclassName = attributesSupport.DataDescriptionDatabaseColumn(typeof(Classification), "Superclass");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = superclassName,
                Values = new object[] { superclass.Id },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Classification result = ConvertAllFields(reader);
            return result;
        }

        public Classification[] SelectAll()
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Classification));

            statement.SelectBuilder.BuildTableName(tableName);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Classification[] result = ConvertAllFieldsArray(reader);
            return result;
        }

        private Classification ConvertAllFields(IDataReader reader)
        {
            Classification result = new Classification();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private Classification[] ConvertAllFieldsArray(IDataReader reader)
        {
            List<Classification> result = new List<Classification>();
            while (reader.Read())
            {
                Classification t = GetOne(reader);
                result.Add(t);
            }

            return result.ToArray();
        }

        private Classification GetOne(IDataReader reader)
        {
            SqlGetData sqlGetData = new SqlGetData();
            SqlForClassification sqlForClassification = new SqlForClassification();
            int? scId = sqlGetData.GetNullableInt32(reader, 3);
            Classification t = new Classification
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = sqlGetData.GetNullableString(reader, 2),
                Superclass = scId == null ? null : sqlForClassification.SelectById((int)scId)
            };

            return t;
        }
    }
}