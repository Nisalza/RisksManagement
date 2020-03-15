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
    public class SqlForRisksManagementPlan : SqlForModel
    {
        public RiskManagementPlan SelectById(int pId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(RiskManagementPlan));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(RiskManagementPlan), "Id");
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
            RiskManagementPlan result = ConvertAllFields(reader);
            return result;
        }

        public RiskManagementPlan[] SelectAll()
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(RiskManagementPlan));

            statement.SelectBuilder.BuildTableName(tableName);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            RiskManagementPlan[] result = ConvertAllFieldsArray(reader);
            return result;
        }

        private RiskManagementPlan ConvertAllFields(IDataReader reader)
        {
            RiskManagementPlan result = new RiskManagementPlan();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private RiskManagementPlan[] ConvertAllFieldsArray(IDataReader reader)
        {
            List<RiskManagementPlan> result = new List<RiskManagementPlan>();
            RiskManagementPlan sqlForProbabilityType = new RiskManagementPlan();
            while (reader.Read())
            {
                RiskManagementPlan t = GetOne(reader);
                result.Add(t);
            }

            return result.ToArray();
        }

        private RiskManagementPlan GetOne(IDataReader reader)
        {
            SqlForStrategy sqlForStrategy = new SqlForStrategy();
            SqlGetData sqlGetData = new SqlGetData();

            int? mitigation = sqlGetData.GetNullableInt32(reader, 1);
            int? contingency = sqlGetData.GetNullableInt32(reader, 2);
            RiskManagementPlan t = new RiskManagementPlan
            {
                Id = reader.GetInt32(0),
                MitigationStrategy =
                    mitigation == null ? new Strategy() : sqlForStrategy.SelectById((int) mitigation),
                ContingencyStrategy =
                contingency == null ? new Strategy() : sqlForStrategy.SelectById((int)contingency)
            };

            return t;
        }
    }
}