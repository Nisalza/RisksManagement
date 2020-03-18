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
    public class SqlForStrategy : SqlForModel
    {

        private string[] GetCols()
        {
            AttributesSupport attributesSupport = new AttributesSupport();
            string[] cols =
            {
                attributesSupport.DataDescriptionDatabaseColumn(typeof(Strategy), "Description"),
                attributesSupport.DataDescriptionDatabaseColumn(typeof(Strategy), "StrategyType")
            };

            return cols;
        }

        private object[] GetVals(Strategy strategy)
        {
            AttributesSupport attributesSupport = new AttributesSupport();
            object[] vals =
            {
                strategy.Description,
                strategy.StrategyType.Id
            };

            return vals;
        }

        public Strategy SelectById(int strategyId)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Strategy));

            var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(Strategy), "Id");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = id,
                Values = new object[] { strategyId },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Strategy result = ConvertAllFields(reader);
            return result;
        }

        public Strategy[] SelectAllByType(StrategyType type)
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Strategy));

            var strategyType = attributesSupport.DataDescriptionDatabaseColumn(typeof(Strategy), "StrategyType");
            ConditionClause c1 = new ConditionClause
            {
                ColumnName = strategyType,
                Values = new object[] { type.Id },
                Operator = Dictionaries.ComparisonOperators.EqualTo
            };
            var where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[] { (null, false, c1) };

            statement.SelectBuilder.BuildTableName(tableName);
            statement.SelectBuilder.BuildWhere(where);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Strategy[] result = ConvertAllFieldsArray(reader);
            return result;
        }

        public Strategy[] SelectAll()
        {
            SelectStatement statement = QueryFactory.Select() as SelectStatement;

            AttributesSupport attributesSupport = new AttributesSupport();
            string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Strategy));

            statement.SelectBuilder.BuildTableName(tableName);

            string text = statement.GetRequest();
            SqlExecutor sqlExecutor = new SqlExecutor();
            var reader = sqlExecutor.ExecuteReader(text);
            Strategy[] result = ConvertAllFieldsArray(reader);
            return result;
        }

        public bool InsertStrategy(Strategy strategy, AppUser user)
        {
            bool ok = true;

            try
            {
                InsertStatement statement = QueryFactory.Insert() as InsertStatement;

                AttributesSupport attributesSupport = new AttributesSupport();
                string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Strategy));

                string[] createdCols =
                {
                    attributesSupport.DataDescriptionDatabaseColumn(typeof(Strategy), "TimeCreated"),
                    attributesSupport.DataDescriptionDatabaseColumn(typeof(Strategy), "CreatedBy")
                };
                string[] cols = GetCols();
                cols = cols.Concat(createdCols).ToArray();

                object[] createdValues = { DateTime.Now, user.Login };
                object[] values = GetVals(strategy);
                values = values.Concat(createdValues).ToArray();

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

        public bool UpdateStrategy(Strategy strategy, AppUser user)
        {
            bool ok = true;

            try
            {
                UpdateStatement statement = QueryFactory.Update() as UpdateStatement;

                AttributesSupport attributesSupport = new AttributesSupport();
                string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Strategy));

                string[] createdCols =
                {
                    attributesSupport.DataDescriptionDatabaseColumn(typeof(Strategy), "TimeModified"),
                    attributesSupport.DataDescriptionDatabaseColumn(typeof(Strategy), "ModifiedBy")
                };
                string[] cols = GetCols();
                cols = cols.Union(createdCols).ToArray();

                object[] createdValues = { DateTime.Now, user.Login };
                object[] values = GetVals(strategy);
                values = values.Union(createdValues).ToArray();

                List<(string, object)> v = new List<(string, object)>();
                for (int i = 0; i < values.Length && i < cols.Length; ++i)
                {
                    v.Add((cols[i], values[i]));
                }

                var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(Strategy), "Id");
                ConditionClause c1 = new ConditionClause
                {
                    ColumnName = id,
                    Values = new object[] { strategy.Id },
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

        public bool DeleteStrategy(Strategy strategy)
        {
            bool ok = true;

            try
            {
                DeleteStatement statement = QueryFactory.Delete() as DeleteStatement;

                AttributesSupport attributesSupport = new AttributesSupport();
                string tableName = attributesSupport.DataDescriptionDatabaseTable(typeof(Strategy));

                var id = attributesSupport.DataDescriptionDatabaseColumn(typeof(Strategy), "Id");
                ConditionClause c1 = new ConditionClause
                {
                    ColumnName = id,
                    Values = new object[] { strategy.Id },
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

        private Strategy ConvertAllFields(IDataReader reader)
        {
            Strategy result = new Strategy();
            while (reader.Read())
            {
                result = GetOne(reader);
            }

            return result;
        }

        private Strategy[] ConvertAllFieldsArray(IDataReader reader)
        {
            List<Strategy> result = new List<Strategy>();
            while (reader.Read())
            {
                var t = GetOne(reader);
                result.Add(t);
            }

            return result.ToArray();
        }

        private Strategy GetOne(IDataReader reader)
        {
            SqlForStrategyType sqlForStrategyType = new SqlForStrategyType();
            int ptId = reader.GetInt32(2);
            Strategy t = new Strategy
            {
                Id = reader.GetInt32(0),
                Description = reader.GetString(1),
                StrategyType = sqlForStrategyType.SelectById(ptId)
            };

            return t;
        }
    }
}