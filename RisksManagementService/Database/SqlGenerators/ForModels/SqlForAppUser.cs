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
    public class SqlForAppUser
    {
        private readonly IQueryFactory _queryFactory;

        public SqlForAppUser()
        {
            _queryFactory = new SqlServerQueriesFactory();
        }

        public AppUser SelectAllByLogin(string userLogin)
        {
            SelectStatement statement = _queryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(AppUser));
            statement.SelectBuilder.BuildTableName(tableName);

            var login = attributesSupport.DataDescriptionDatabaseColumn(typeof(AppUser), "Login");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = login,
                Values = new object[] {userLogin},
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] {(null, false, c1)};
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlSupport support = new SqlSupport();
            var reader = support.ExecuteReader(text);
            AppUser result = ConvertReaderToAppUser(reader);
            return result;
        }

        private AppUser ConvertReaderToAppUser(IDataReader reader)
        {
            AppUser result = new AppUser();
            while (reader.Read())
            {
                result.Id = reader.GetInt32(0);
                result.Name = reader.GetString(1);
                result.Login = reader.GetString(2);
                result.Role = new Role
                {
                    Id = reader.GetInt32(3)
                };
                result.Email = reader.GetString(4);
                result.IsAdmin = reader.GetInt32(5) == 1;
            }

            return result;
        }
    }
}