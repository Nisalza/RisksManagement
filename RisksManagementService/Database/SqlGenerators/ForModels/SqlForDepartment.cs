﻿using System;
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
    public class SqlForDepartment : SqlForModel
    {
        public Department SelectById(int depId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Department));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(Department), "Id");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = id,
                Values = new object[] { depId },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Department result = ConvertAllFields(reader);
            return result;
        }

        private Department ConvertAllFields(IDataReader reader)
        {
            Department result = new Department();
            //SqlForAppUser sqlForAppUser = new SqlForAppUser();
            while (reader.Read())
            {
                result.Id = reader.GetInt32(0);
                result.Name = reader.GetString(1);
                result.Description = reader.GetString(2);
                result.Supervisor = new AppUser();
                //todo Раскомментировать для руководителя подразделения
                //int userId = reader.GetInt32(3);
                //result.Supervisor = sqlForAppUser.SelectById(userId);
            }

            return result;
        }
    }
}