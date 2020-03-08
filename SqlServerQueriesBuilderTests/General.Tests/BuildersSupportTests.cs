﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlServerQueriesBuilder.General;

namespace SqlServerQueriesBuilderTests.General.Tests
{
    [TestClass]
    public class BuildersSupportTests
    {
        [TestMethod]
        public void ArrayToStringWithComma_Obj_NoElements()
        {
            //Arrange
            object[] array = new object[0];
            string expected = "";

            //Act
            string result = new BuildersSupport().ArrayToStringWithComma(array);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ArrayToStringWithComma_Obj_OneElement()
        {
            //Arrange
            object[] array = {45};
            string expected = "\'45\'";

            //Act
            string result = new BuildersSupport().ArrayToStringWithComma(array);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ArrayToStringWithComma_Obj_SomeElements()
        {
            //Arrange
            object[] array = {5, 't', "str", -6};
            string expected = "\'5\', \'t\', \'str\', \'-6\'";

            //Act
            string result = new BuildersSupport().ArrayToStringWithComma(array);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ArrayToStringWithComma_Str_NoElements()
        {
            //Arrange
            string[] array = new string[0];
            string expected = "";

            //Act
            string result = new BuildersSupport().ArrayToStringWithComma(array);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ArrayToStringWithComma_Str_OneElement()
        {
            //Arrange
            string[] array = {"str1"};
            string expected = "\'str1\'";

            //Act
            string result = new BuildersSupport().ArrayToStringWithComma(array);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ArrayToStringWithComma_Str_SomeElements()
        {
            //Arrange
            string[] array = {"a3", "o.o", "temp", "", "!"};
            string expected = "\'a3\', \'o.o\', \'temp\', \'\', \'!\'";

            //Act
            string result = new BuildersSupport().ArrayToStringWithComma(array);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(Dictionaries.ComparisonOperators.In)]
        [DataRow(Dictionaries.ComparisonOperators.All)]
        public void BuildComparison_In_All(Dictionaries.ComparisonOperators co)
        {
            //Arrange
            object[] array = {"qwerty", 45, '?'};
            string expected = "(\'qwerty\', \'45\', \'?\')";

            //Act
            string result = new BuildersSupport().BuildComparison(co, array);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(Dictionaries.ComparisonOperators.NotEqualTo)]
        [DataRow(Dictionaries.ComparisonOperators.EqualTo)]
        [DataRow(Dictionaries.ComparisonOperators.Like)]
        [DataRow(Dictionaries.ComparisonOperators.GreaterThen)]
        [DataRow(Dictionaries.ComparisonOperators.GreaterThanOrEqualTo)]
        [DataRow(Dictionaries.ComparisonOperators.LessThen)]
        [DataRow(Dictionaries.ComparisonOperators.LessThanOrEqualTo)]
        public void BuildComparison_Others(Dictionaries.ComparisonOperators co)
        {
            //Arrange
            object[] array = { "qwerty" };
            string expected = "\'qwerty\'";

            //Act
            string result = new BuildersSupport().BuildComparison(co, array);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ArrayToStringWithComma_Str_TableName()
        {
            //Arrange
            string[] array = {"c1", "c2"};
            string tn = "table";
            string expected = "[table].[c1], [table].[c2]";

            //Act
            string result = new BuildersSupport().ArrayToStringWithComma(tn, array);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RealNumbersConverter()
        {
            //Arrange
            object[] array = {4.5f, "abc", 5, -2.8f};
            object[] expected = {"4.5", "abc", 5, "-2.8"};

            //Act
            object[] res = new BuildersSupport().RealNumbersConverter(array);

            //Assert
            CollectionAssert.AreEqual(expected, res);
        }

        [TestMethod]
        public void RealNumbersConverter_OneItem_Float()
        {
            //Arrange
            object array = 4.5f;
            object expected = "4.5";

            //Act
            object res = new BuildersSupport().RealNumbersConverter(array);

            //Assert
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void RealNumbersConverter_OneItem_String()
        {
            //Arrange
            object array = "!qwe";
            object expected = "!qwe";

            //Act
            object res = new BuildersSupport().RealNumbersConverter(array);

            //Assert
            Assert.AreEqual(expected, res);
        }
    }
}
