using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductID = 1;
            currentProduct.Description = "15-inch steel blade hand saw";
            currentProduct.ProductVendor.CompanyName = "ABC Corp";
            var expected = "Hello Saw (1): 15-inch steel blade hand saw";            //Act

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod()]
        public void SayHello_ParameterizedConstructor()
        {
            //Arrange
            var currentProduct = new Product(1, "Saw", 
                                 "15-inch steel blade hand saw");
                        
            var expected = "Hello Saw (1): 15-inch steel blade hand saw";            //Act

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(actual, expected);

        }
        [TestMethod()]
        public void Product_Null()
        {
            //Arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;

            //Act
            var actual = companyName;

            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]  
        public void ProductName_Format()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "   Steel Hammer   ";

            var expected = "Steel Hammer";
            //act
            var actual = currentProduct.ProductName;

            //assert
            Assert.AreEqual(expected, actual);

         }
        [TestMethod()]

        public void ProductCode_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();

            var expected = "Tools-1";

            //Act
            var actual = currentProduct.ProductCode;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}