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
    public class SqlForImpactType : SqlForModel
    {
        public ImpactType SelectById(int itId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(ImpactType));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(ImpactType), "Id");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = id,
                Values = new object[] { itId },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            ImpactType result = ConvertAllFields(reader);
            return result;
        }

        public ImpactType[] SelectAll()
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(ImpactType));

            statement.SelectBuilder.BuildTableName(tableName);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            ImpactType[] result = ConvertAllFieldsArray(reader);
            return result;
        }

        private ImpactType ConvertAllFields(IDataReader reader)
        {
            ImpactType result = new ImpactType();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private ImpactType[] ConvertAllFieldsArray(IDataReader reader)
        {
            List<ImpactType> result = new List<ImpactType>();
            while (reader.Read())
            {
                var t = GetOne(reader);
                result.Add(t);
            }

            return result.ToArray();
        }

        private ImpactType GetOne(IDataReader reader)
        {
            ImpactType t = new ImpactType
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1)
            };

            return t;
        }
    }
}