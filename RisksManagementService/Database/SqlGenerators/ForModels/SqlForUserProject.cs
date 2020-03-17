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
    public class SqlForUserProject : SqlForModel
    {
        public UserProject[] SelectAllByAppUser(AppUser user)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(UserProject));

            var userDbName = attributesSupport.DataDescriptionDatabaseColumn(typeof(UserProject), "AppUser");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = userDbName,
                Values = new object[] { user.Id },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            UserProject[] result = ConvertAllFields(reader);
            return result;
        }

        public UserProject[] SelectAllByProject(Project project)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(UserProject));

            var userDbName = attributesSupport.DataDescriptionDatabaseColumn(typeof(UserProject), "Project");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = userDbName,
                Values = new object[] { project.Id },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            UserProject[] result = ConvertAllFields(reader);
            return result;
        }

        public UserProject[] SelectAll()
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(UserProject));

            statement.SelectBuilder.BuildTableName(tableName);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            UserProject[] result = ConvertAllFields(reader);
            return result;
        }

        private UserProject[] ConvertAllFields(IDataReader reader)
        {
            List<UserProject> result = new List<UserProject>();
            while (reader.Read())
            {
                UserProject record = GetOne(reader);
                result.Add(record);
            }

            return result.ToArray();
        }

        private UserProject GetOne(IDataReader reader)
        {
            SqlForAppUser sqlForAppUser = new SqlForAppUser();
            int userId = reader.GetInt32(1);
            SqlForProject sqlForProject = new SqlForProject();
            int projectId = reader.GetInt32(2);
            UserProject record = new UserProject
            {
                AppUser = sqlForAppUser.SelectById(userId),
                Project = sqlForProject.SelectById(projectId)
            };

            return record;
        }
    }
}