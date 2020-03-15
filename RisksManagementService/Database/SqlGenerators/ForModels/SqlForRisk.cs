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
    public class SqlForRisk : SqlForModel
    {
        public Risk SelectById(int riskId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Risk));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "Id");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = id,
                Values = new object[] { riskId },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Risk result = ConvertAllFields(reader);
            return result;
        }

        public Risk SelectByUser(AppUser user)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Risk));

            var rpDbName = attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "ResponsiblePerson");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = rpDbName,
                Values = new object[] { user.Id },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Risk result = ConvertAllFields(reader);
            return result;
        }

        public Risk SelectByProject(Project project)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Risk));

            var projectDbName = attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "Project");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = projectDbName,
                Values = new object[] { project.Id },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Risk result = ConvertAllFields(reader);
            return result;
        }

        private Risk ConvertAllFields(IDataReader reader)
        {
            Risk result = new Risk();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private Risk[] ConvertAllFieldsArray(IDataReader reader)
        {
            List<Risk> result = new List<Risk>();
            while (reader.Read())
            {
                Risk t = GetOne(reader);
                result.Add(t);
            }

            return result.ToArray();
        }

        private Risk GetOne(IDataReader reader)
        {
            SqlGetData sqlGetData = new SqlGetData();
            SqlForProbability sqlForProbability = new SqlForProbability();
            int probability = reader.GetInt32(3);
            SqlForImpact sqlForImpact = new SqlForImpact();
            int impact = reader.GetInt32(4);
            SqlForPriority sqlForPriority = new SqlForPriority();
            int priority = reader.GetInt32(5);
            SqlForAppUser sqlForAppUser = new SqlForAppUser();
            int appUser = reader.GetInt32(6);
            SqlForRisksManagementPlan sqlForRisksManagementPlan = new SqlForRisksManagementPlan();
            int? mngPlan = sqlGetData.GetNullableInt32(reader, 7);
            SqlForRelevance sqlForRelevance = new SqlForRelevance();
            int relevance = reader.GetInt32(8);
            SqlForRiskCause sqlForRiskCause = new SqlForRiskCause();
            int? cause = sqlGetData.GetNullableInt32(reader, 9);
            SqlForProject sqlForProject = new SqlForProject();
            int project = reader.GetInt32(11);
            SqlForClassification sqlForClassification = new SqlForClassification();
            int classification = reader.GetInt32(13);
            SqlForExposureComputation sqlForExposureComputation = new SqlForExposureComputation();
            int ec = reader.GetInt32(14);

            Risk t = new Risk
            {
                Id = reader.GetInt32(0),
                Name = reader.GetName(1),
                Description = sqlGetData.GetNullableString(reader, 2),
                Probability = sqlForProbability.SelectById(probability),
                Impact = sqlForImpact.SelectById(impact),
                Priority = sqlForPriority.SelectById(priority),
                ResponsiblePerson = sqlForAppUser.SelectById(appUser),
                RiskManagementPlan = mngPlan == null ? new RiskManagementPlan() : sqlForRisksManagementPlan.SelectById((int)mngPlan),
                IsRelevance = sqlForRelevance.SelectById(relevance),
                RiskCause = cause == null ? new RiskCause() : sqlForRiskCause.SelectById((int)cause),
                Damage = sqlGetData.GetNullableString(reader, 10),
                Project = sqlForProject.SelectById(project),
                Deadline = sqlGetData.GetNullableString(reader, 12),
                Classification = sqlForClassification.SelectById(classification),
                ExposureComputation = sqlForExposureComputation.SelectById(ec)
            };

            t.Value = t.Probability.Assessment * t.Impact.Assessment;

            return t;
        }
    }
}