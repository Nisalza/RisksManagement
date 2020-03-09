using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlServerQueriesBuilder.DeleteStatement;
using SqlServerQueriesBuilder.Exceptions;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilderTests
{
    [TestClass]
    public class DeleteQueryTests
    {
        [TestMethod]
        [ExpectedException(typeof(NoRequiredDataException))]
        public void ToString_NoTableName()
        {
            //Arrange
            DeleteQuery q = new DeleteQuery();

            //Act
            q.ToString();
        }

        [TestMethod]
        [ExpectedException(typeof(NoRequiredDataException))]
        public void ToString_EmptyTableName()
        {
            //Arrange
            DeleteQuery q = new DeleteQuery()
            {
                TableName = ""
            };
            
            //Act
            q.ToString();
        }

        [TestMethod]
        public void ToString_Delete()
        {
            //Arrange
            DeleteQuery q = new DeleteQuery()
            {
                TableName = "table"
            };
            string expected = "delete from [table] ";

            //Act
            string res = q.ToString();

            //Assert
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void ToString_Where()
        {
            //Arrange
            DeleteQuery q = new DeleteQuery()
            {
                TableName = "table",
                Where = new (Dictionaries.LogicOperators?, bool, ConditionClause)[]
                {
                    (null, false, new ConditionClause { ColumnName = "Col1",  Operator = Dictionaries.ComparisonOperators.EqualTo, Values = new object[] {"abc"}} )
                }
            };
            string expected = "delete from [table] " +
                              "where [table].[Col1] = \'abc\' ";

            //Act
            string res = q.ToString();

            //Assert
            Assert.AreEqual(expected, res);
        }
    }
}
