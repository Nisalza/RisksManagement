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
    public class SqlForProject : SqlForModel
    {
        public Project SelectById(int projectId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Project));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(Project), "Id");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = id,
                Values = new object[] {projectId},
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] {(null, false, c1)};

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Project result = ConvertAllFields(reader);
            return result;
        }

        private Project ConvertAllFields(IDataReader reader)
        {
            Project result = new Project();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private Project GetOne(IDataReader reader)
        {
            SqlForAppUser sqlForAppUser = new SqlForAppUser();
            SqlGetData sqlGetData = new SqlGetData();
            SqlForDepartment sqlForDepartment = new SqlForDepartment();
            int? userId = sqlGetData.GetNullableInt32(reader, 3);
            int depId = reader.GetInt32(4);
            Project result = new Project
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = sqlGetData.GetNullableString(reader, 2),
                Supervisor = userId == null ? new AppUser() : sqlForAppUser.SelectById((int) userId),
                Department = sqlForDepartment.SelectById(depId)
            };

            return result;
        }
    }
}