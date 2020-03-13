﻿using System;
using System.Collections.Generic;
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
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
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
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            AppUser result = ConvertAllFields(reader);
            return result;
        }

        public bool UpdateByUser(AppUser user)
        {
            bool ok = true;

            try
            {
                UpdateStatement statement = QueryFactory.Update() as UpdateStatement;

                AttributesSupport attributesSupport = new AttributesSupport();
                string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(AppUser));

                var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(AppUser), "Id");
                var phone = attributesSupport.DataDescriptionDatabaseColumn(typeof(AppUser), "Phone");
                var email = attributesSupport.DataDescriptionDatabaseColumn(typeof(AppUser), "Email");
                var telegram = attributesSupport.DataDescriptionDatabaseColumn(typeof(AppUser), "Telegram");
                List<(string, object)> values = new List<(string, object)>
                    {(phone, user.Phone), (email, user.Email), (telegram, user.Telegram)};
                values.AddRange(CreateModified(user.Login));

                ConditionClause c1 = new ConditionClause
                {
                    ColumnName = id,
                    Values = new object[] { user.Id },
                    Operator = Dictionaries.ComparisonOperators.EqualTo
                };
                var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

                statement.UpdateBuilder.BuildTableName(tableName);
                statement.UpdateBuilder.BuildValues(values.ToArray());
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

        private (string, object)[] CreateModified(string login)
        {
            AttributesSupport attributesSupport = new AttributesSupport();
            var modifiedBy = attributesSupport.DataDescriptionDatabaseColumn(typeof(AppUser), "ModifiedBy");
            var timeModified = attributesSupport.DataDescriptionDatabaseColumn(typeof(AppUser), "TimeModified");

            (string, object)[] result = { (modifiedBy, login), (timeModified, DateTime.Now) };
            return result;
        }

        private AppUser ConvertAllFields(IDataReader reader)
        {
            AppUser result = new AppUser();
            SqlGetData sqlGetData = new SqlGetData();
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
                result.Phone = sqlGetData.GetNullableString(reader, 4);
                result.Email = sqlGetData.GetNullableString(reader, 5);
                result.Telegram = sqlGetData.GetNullableString(reader, 6);
                result.IsAdmin = reader.GetBoolean(7);
            }

            return result;
        }
    }
}