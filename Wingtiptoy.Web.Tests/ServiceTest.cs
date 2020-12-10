using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Wingtiptoy.Web.Services;

namespace Wingtiptoy.Web.Tests
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void SearchProductsByCategory_SearchTextLengthIsLessThan2Characters_ReturnsZeroProducts()
        {
            //Arrange
            string searchString = "c";
            bool isSuccessStatusCode;


            //Act
            var result = Service.SearchProductsByCategory(1, searchString, out isSuccessStatusCode);

            //Assert
            if (isSuccessStatusCode)
            {
                Assert.IsTrue(result.Count() > 0, "returns some records");
            }
        }
    }
}
