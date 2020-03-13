using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using RisksManagementService.Attributes;
using RisksManagementService.Database.Models;
using RisksManagementService.Database.Queries;
using RisksManagementService.Database.Queries.Statements;
using SqlServerQueriesBuilder.General;

namespace RisksManagementService.Database.SqlGenerators.ForModels
{
    public class SqlForAppUser : SqlForModel
    {
        public AppUser SelectByLogin(string userLogin)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(AppUser));

            var login = attributesSupport.DataDescriptionDatabaseColumn(typeof(AppUser), "Login");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = login,
                Values = new object[] {userLogin},
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] {(null, false, c1)};

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlSupport sqlSupport = new SqlSupport();
            var reader = sqlSupport.ExecuteReader(text);
            AppUser result = ConvertAllFields(reader);
            return result;
        }

        public AppUser SelectById(int userId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(AppUser));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(AppUser), "Id");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = id,
                Values = new object[] { userId },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlSupport sqlSupport = new SqlSupport();
            var reader = sqlSupport.ExecuteReader(text);
            AppUser result = ConvertAllFields(reader);
            return result;
        }

        private AppUser ConvertAllFields(IDataReader reader)
        {
            AppUser result = new AppUser();
            while (reader.Read())
            {
                result.Id = reader.GetInt32(0);
                result.Name = reader.GetString(1);
                result.Login = reader.GetString(2);
                //todo Сделать когда будет необходимость в разделении ролей пользователей
                //result.Role = new Role
                //{
                //    Id = reader[3] == null ? reader.GetInt32(3) : 0
                //};
                result.Email = reader.GetString(4);
                result.IsAdmin = reader.GetBoolean(5);
            }

            return result;
        }
    }
}