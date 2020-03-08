using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlServerQueriesBuilder.Exceptions;
using SqlServerQueriesBuilder.General;
using SqlServerQueriesBuilder.UpdateStatement;

namespace SqlServerQueriesBuilderTests
{
    [TestClass]
    public class UpdateQueryTests
    {
        [TestMethod]
        [ExpectedException(typeof(NoRequiredDataException))]
        public void ToString_NullTableName()
        {
            //Arrange
            var q = new UpdateQuery();

            //Act
            q.ToString();
        }

        [TestMethod]
        [ExpectedException(typeof(NoRequiredDataException))]
        public void ToString_EmptyTableName()
        {
            //Arrange
            var q = new UpdateQuery()
            {
                TableName = ""
            };

            //Act
            q.ToString();
        }

        [TestMethod]
        [ExpectedException(typeof(NoRequiredDataException))]
        public void ToString_NullValues()
        {
            //Arrange
            var q = new UpdateQuery()
            {
                TableName = "t"
            };

            //Act
            q.ToString();
        }

        [TestMethod]
        [ExpectedException(typeof(NoRequiredDataException))]
        public void ToString_EmptyValues()
        {
            //Arrange
            var q = new UpdateQuery()
            {
                TableName = "t",
                Values = new (string, object)[0]
            };

            //Act
            q.ToString();
        }

        [TestMethod]
        public void ToString_Values()
        {
            //Arrange
            var q = new UpdateQuery()
            {
                TableName = "t",
                Values = new (string, object)[]
                {
                    ("Col1", 45),
                    ("Col2", "temp")
                }
            };
            string expected = "update [t] " +
                              "set [t].[Col1] = \'45\', [t].[Col2] = \'temp\' ";

            //Act
            string res = q.ToString();

            //Assert
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void ToString_Where()
        {
            //Arrange
            var q = new UpdateQuery()
            {
                TableName = "t",
                Values = new (string, object)[]
                {
                    ("Col1", 45),
                    ("Col2", "temp")
                },
                Where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[]
                {
                    (null, false, new ConditionClause { ColumnName = "Col1",  Operator = Dictionaries.ComparisonOperators.EqualTo, Values = new object[] {"abc"}} )
                }
            };
            string expected = "update [t] " +
                              "set [t].[Col1] = \'45\', [t].[Col2] = \'temp\' " +
                              "where [t].[Col1] = \'abc\' ";

            //Act
            string res = q.ToString();

            //Assert
            Assert.AreEqual(expected, res);
        }
    }
}
