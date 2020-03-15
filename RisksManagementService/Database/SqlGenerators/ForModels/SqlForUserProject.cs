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

            var appUser = attributesSupport.DataDescriptionDatabaseColumn(typeof(UserProject), "AppUser");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = appUser,
                Values = new object[] { user.Id },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            UserProject[] result = ConvertAllFields(reader, user);
            return result;
        }

        private UserProject[] ConvertAllFields(IDataReader reader, AppUser user)
        {
            List<UserProject> result = new List<UserProject>();
            while (reader.Read())
            {
                UserProject record = GetOne(reader, user);
                result.Add(record);
            }

            return result.ToArray();
        }

        private UserProject GetOne(IDataReader reader, AppUser user)
        {
            SqlForProject sqlForProject = new SqlForProject();
            int projectId = reader.GetInt32(2);
            UserProject record = new UserProject
            {
                AppUser = user,
                Project = sqlForProject.SelectById(projectId)
            };

            return record;
        }
    }
}