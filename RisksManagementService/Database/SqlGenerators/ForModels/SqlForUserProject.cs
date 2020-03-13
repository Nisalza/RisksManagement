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

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(UserProject), "Id");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = id,
                Values = new object[] { user.Id },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlSupport sqlSupport = new SqlSupport();
            var reader = sqlSupport.ExecuteReader(text);
            UserProject[] result = ConvertAllFields(reader, user);
            return result;
        }

        private UserProject[] ConvertAllFields(IDataReader reader, AppUser user)
        {
            List<UserProject> result = new List<UserProject>();
            SqlForProject sqlForProject = new SqlForProject();
            while (reader.Read())
            {
                int projectId = reader.GetInt32(2);
                UserProject record = new UserProject
                {
                    AppUser = user,
                    Project = sqlForProject.SelectById(projectId)
                };
                result.Add(record);
            }

            return result.ToArray();
        }
    }
}