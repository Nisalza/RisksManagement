using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlServerQueriesBuilder.Exceptions;
using SqlServerQueriesBuilder.General;
using SqlServerQueriesBuilder.SelectStatement;

namespace SqlServerQueriesBuilderTests
{
    [TestClass]
    public class SelectQueryTests
    {
        [TestMethod]
        [ExpectedException(typeof(NoRequiredDataException))]
        public void ToString_NullTableName()
        {
            //Arrange
            var q = new SelectQuery()
            {
                Columns = new[] {"", ""}
            };

            //Act
            q.ToString();
        }

        [TestMethod]
        public void ToString_NullColumns()
        {
            //Arrange
            var q = new SelectQuery()
            {
                TableName = "t"
            };
            string expected = "select [t].* from [t] ";

            //Act
            string res = q.ToString();

            //Assert
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void ToString_NoColumns()
        {
            //Arrange
            var q = new SelectQuery()
            {
                TableName = "t",
                Columns = new string[0]
            };
            string expected = "select [t].* from [t] ";

            //Act
            string res = q.ToString();

            //Assert
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void ToString_BaseQuery_OneColumn()
        {
            //Arrange
            var q = new SelectQuery()
            {
                TableName = "SomeTable",
                Columns = new[] {"Col1"}
            };
            string expected = "select [SomeTable].[Col1] " +
                              "from [SomeTable] ";

            //Act
            string res = q.ToString();

            //Assert
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void ToString_BaseQuery_Distinct()
        {
            //Arrange
            var q = new SelectQuery()
            {
                TableName = "SomeTable",
                Columns = new[] { "Col1", "Col2", "Col3" },
                Distinct = true
            };
            string expected = "select distinct [SomeTable].[Col1], [SomeTable].[Col2], [SomeTable].[Col3] " +
                              "from [SomeTable] ";

            //Act
            string res = q.ToString();

            //Assert
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void ToString_BaseQuery_Where()
        {
            //Arrange
            var q = new SelectQuery()
            {
                TableName = "SomeTable",
                Columns = new[] { "Col1", "Col2", "Col3" },
                Distinct = true,
                Where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[]
                {
                     (null, false, new ConditionClause { ColumnName = "Col1",  Operator = Dictionaries.ComparisonOperators.EqualTo, Values = new object[] {"abc"}} )
                }
            };
            string expected = "select distinct [SomeTable].[Col1], [SomeTable].[Col2], [SomeTable].[Col3] " +
                              "from [SomeTable] " +
                              "where [SomeTable].[Col1] = \'abc\' ";

            //Act
            string res = q.ToString();

            //Assert
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void ToString_BaseQuery_Where_WithNot()
        {
            //Arrange
            var q = new SelectQuery()
            {
                TableName = "SomeTable",
                Columns = new[] { "Col1", "Col2", "Col3" },
                Distinct = true,
                Where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[]
                {
                    (null, false, new ConditionClause { ColumnName = "Col1",  Operator = Dictionaries.ComparisonOperators.EqualTo, Values = new object[] {"abc"}} ),
                    (Dictionaries.LogicOperators.Or, true, new ConditionClause { ColumnName = "Col3",  Operator = Dictionaries.ComparisonOperators.In, Values = new object[] {"abc", "bca", "cab"}} )
                }
            };
            string expected = "select distinct [SomeTable].[Col1], [SomeTable].[Col2], [SomeTable].[Col3] " +
                              "from [SomeTable] " +
                              "where [SomeTable].[Col1] = \'abc\' " +
                              "Or not [SomeTable].[Col3] in (\'abc\', \'bca\', \'cab\') ";

            //Act
            string res = q.ToString();

            //Assert
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void ToString_BaseQuery_GroupBy()
        {
            //Arrange
            var q = new SelectQuery()
            {
                TableName = "SomeTable",
                Columns = new[] { "Col1" },
                GroupBy = new [] {"Col3"}
            };
            string expected = "select [SomeTable].[Col1] " +
                              "from [SomeTable] " +
                              "group by [SomeTable].[Col3] ";

            //Act
            string res = q.ToString();

            //Assert
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void ToString_BaseQuery_HavingWithoutGroupBy()
        {
            //Arrange
            var q = new SelectQuery()
            {
                TableName = "SomeTable",
                Columns = new[] { "Col1" },
                Having = new (Dictionaries.LogicOperators?, bool, ConditionClause)[0]
            };
            string expected = "select [SomeTable].[Col1] " +
                              "from [SomeTable] ";

            //Act
            string res = q.ToString();

            //Assert
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void ToString_BaseQuery_GroupByAndHaving()
        {
            //Arrange
            var q = new SelectQuery()
            {
                TableName = "SomeTable",
                Columns = new[] {"Col1"},
                GroupBy = new[] {"Col3"},
                Having = new (Dictionaries.LogicOperators?, bool, ConditionClause)[]
                {
                    (null, false,
                        new ConditionClause
                        {
                            ColumnName = "Col1", Operator = Dictionaries.ComparisonOperators.EqualTo,
                            Values = new object[] {"abc"}
                        }),
                    (Dictionaries.LogicOperators.And, true,
                        new ConditionClause
                        {
                            ColumnName = "Col3", Operator = Dictionaries.ComparisonOperators.All,
                            Values = new object[] {"abc", "bca", "cab"}
                        })
                }
            };
            string expected = "select [SomeTable].[Col1] " +
                              "from [SomeTable] " +
                              "group by [SomeTable].[Col3] " +
                              "having [SomeTable].[Col1] = \'abc\' " +
                              "And not [SomeTable].[Col3] all (\'abc\', \'bca\', \'cab\') ";

            //Act
            string res = q.ToString();

            //Assert
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void ToString_BaseQuery_OrderBy()
        {
            //Arrange
            var q = new SelectQuery()
            {
                TableName = "SomeTable",
                Columns = new[] { "Col1", "Col2" },
                OrderBy = new[]
                {
                    ("Col1", Dictionaries.OrderBy.Desc) ,
                    ("Col2", Dictionaries.OrderBy.Asc)
                }
            };
            string expected = "select [SomeTable].[Col1], [SomeTable].[Col2] " +
                              "from [SomeTable] " +
                              "order by [SomeTable].[Col1] Desc, [SomeTable].[Col2] Asc ";

            //Act
            string res = q.ToString();

            //Assert
            Assert.AreEqual(expected, res);
        }
    }
}
