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
    public class SqlForUserDepartment : SqlForModel
    {
        public UserDepartment[] SelectAllByAppUser(AppUser user)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(UserDepartment));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(UserDepartment), "Id");
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
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            UserDepartment[] result = ConvertAllFields(reader, user);
            return result;
        }

        private UserDepartment[] ConvertAllFields(IDataReader reader, AppUser user)
        {
            List<UserDepartment> result = new List<UserDepartment>();
            SqlForDepartment sqlForDepartment = new SqlForDepartment();
            while (reader.Read())
            {
                int depId = reader.GetInt32(2);
                UserDepartment record = new UserDepartment
                {
                    AppUser = user,
                    Department = sqlForDepartment.SelectById(depId)
                };
                result.Add(record);
            }

            return result.ToArray();
        }
    }
}