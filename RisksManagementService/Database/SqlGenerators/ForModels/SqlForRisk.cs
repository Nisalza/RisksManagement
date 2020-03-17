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
        private string[] GetCols()
        {
            AttributesSupport attributesSupport = new AttributesSupport();
            string[] cols =
            {
                attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "Name"),
                attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "Description"),
                attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "Probability"),
                attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "Impact"),
                attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "Priority"),
                attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "ResponsiblePerson"),
                attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "RiskManagementPlan"),
                attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "Relevance"),
                attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "RiskCause"),
                attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "Damage"),
                attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "Project"),
                attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "Deadline"),
                attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "Classification"),
                //todo формула
            };

            return cols;
        }

        private object[] GetVals(Risk risk)
        {
            object[] values =
            {
                risk.Name, risk.Description, risk.Probability.Id, risk.Impact.Id, risk.Priority.Id,
                risk.ResponsiblePerson.Id, risk.RiskManagementPlan.Id, risk.IsRelevance.Id,
                risk.Damage, risk.Project.Id, risk.Deadline, risk.Classification.Id, 
                /*todo формула*/ 
            };

            return values;
        }

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

        public bool InsertRisk(Risk risk, AppUser user)
        {
            bool ok = true;

            try
            {
                InsertStatement statement = QueryFactory.Insert() as InsertStatement;

                AttributesSupport attributesSupport = new AttributesSupport();
                string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Risk));

                string[] createdCols =
                {
                    attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "TimeCreated"),
                    attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "CreatedBy")
                };
                string[] cols = GetCols();
                cols = cols.Union(createdCols).ToArray();

                object[] createdValues = {DateTime.Now, user.Login};
                object[] values = GetVals(risk);
                values = values.Union(createdValues).ToArray();

                statement.InsertBuilder.BuildTableName(tableName);
                statement.InsertBuilder.BuildColumns(cols);
                statement.InsertBuilder.BuildValues(values);

                string text = statement.GetRequest();
                SqlExecutor sqlExecutor = new SqlExecutor();
                sqlExecutor.ExecuteReader(text);
            }
            catch (Exception)
            {
                ok = false;
            }

            return ok;
        }

        public bool UpdateRisk(Risk risk, AppUser user)
        {
            bool ok = true;

            try
            {
                UpdateStatement statement = QueryFactory.Update() as UpdateStatement;

                AttributesSupport attributesSupport = new AttributesSupport();
                string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Risk));

                string[] createdCols =
                {
                    attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "TimeModified"),
                    attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "ModifiedBy")
                };
                string[] cols = GetCols();
                cols = cols.Union(createdCols).ToArray();

                object[] createdValues = { DateTime.Now, user.Login };
                object[] values = GetVals(risk);
                values = values.Union(createdValues).ToArray();

                List<(string, object)> v = new List<(string, object)>();
                for (int i = 0; i < values.Length && i < cols.Length; ++i)
                {
                    v.Add((cols[i], values[i]));
                }

                var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "Id");
                ConditionClause c1 = new ConditionClause
                {
                    ColumnName = id,
                    Values = new object[] { risk.Id },
                    Operator = Dictionaries.ComparisonOperators.EqualTo
                };
                var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

                statement.UpdateBuilder.BuildTableName(tableName);
                statement.UpdateBuilder.BuildValues(v.ToArray());
                statement.UpdateBuilder.BuildWhere(where);

                string text = statement.GetRequest();
                SqlExecutor sqlExecutor = new SqlExecutor();
                sqlExecutor.ExecuteReader(text);
            }
            catch (Exception)
            {
                ok = false;
            }

            return ok;
        }

        public bool DeleteRisk(Risk risk)
        {
            bool ok = true;

            try
            {
                DeleteStatement statement = QueryFactory.Delete() as DeleteStatement;

                AttributesSupport attributesSupport = new AttributesSupport();
                string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Risk));

                var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(Risk), "Id");
                ConditionClause c1 = new ConditionClause
                {
                    ColumnName = id,
                    Values = new object[] { risk.Id },
                    Operator = Dictionaries.ComparisonOperators.EqualTo
                };
                var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

                statement.DeleteBuilder.BuildTableName(tableName);
                statement.DeleteBuilder.BuildWhere(where);

                string text = statement.GetRequest();
                SqlExecutor sqlExecutor = new SqlExecutor();
                sqlExecutor.ExecuteReader(text);
            }
            catch (Exception)
            {
                ok = false;
            }

            return ok;
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