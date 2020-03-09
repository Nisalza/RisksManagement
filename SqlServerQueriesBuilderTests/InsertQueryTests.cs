using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlServerQueriesBuilder.Exceptions;
using SqlServerQueriesBuilder.InsertStatement;

namespace SqlServerQueriesBuilderTests
{
    [TestClass]
    public class InsertQueryTests
    {
        [TestMethod]
        [ExpectedException(typeof(NoRequiredDataException))]
        public void ToString_NullTableName()
        {
            //Arrange
            InsertQuery q = new InsertQuery();

            //Act
            q.ToString();
        }

        [TestMethod]
        [ExpectedException(typeof(NoRequiredDataException))]
        public void ToString_EmptyTableName()
        {
            //Arrange
            InsertQuery q = new InsertQuery()
            {
                TableName = ""
            };

            //Act
            q.ToString();
        }

        [TestMethod]
        [ExpectedException(typeof(NoRequiredDataException))]
        public void ToString_NullColumns()
        {
            //Arrange
            InsertQuery q = new InsertQuery()
            {
                TableName = "t",
                Values = new object[0]
            };

            //Act
            q.ToString();
        }

        [TestMethod]
        [ExpectedException(typeof(NoRequiredDataException))]
        public void ToString_NullValues()
        {
            //Arrange
            InsertQuery q = new InsertQuery()
            {
                TableName = "t",
                Columns = new string[0]
            };

            //Act
            q.ToString();
        }

        [TestMethod]
        [ExpectedException(typeof(NoRequiredDataException))]
        public void ToString_ColumnsValuesLength()
        {
            //Arrange
            InsertQuery q = new InsertQuery()
            {
                TableName = "t",
                Columns = new string[5],
                Values = new object[3]
            };

            //Act
            q.ToString();
        }

        [TestMethod]
        public void ToString_Query()
        {
            //Arrange
            InsertQuery q = new InsertQuery()
            {
                TableName = "table",
                Columns = new string[] {"Col1", "Col2", "Col3"},
                Values = new object[] {"123", 123, '!'}
            };
            string expected = "insert into [table] ([Col1], [Col2], [Col3]) values (\'123\', \'123\', \'!\')";

            //Act
            string res = q.ToString();

            //Assert
            Assert.AreEqual(expected, res);
        }
    }
}
