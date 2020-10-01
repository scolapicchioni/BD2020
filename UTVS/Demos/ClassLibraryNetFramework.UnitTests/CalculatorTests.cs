using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibraryNetFramework.UnitTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add1PlusOneShouldReturn2()
        {
            //Arrange (Given)
            Calculator sut = new Calculator();
            int firstOperand = 1;
            int secondOperand = 1;
            int expectedResult = 2;

            //Act (When)
            int actualResult = sut.Add(firstOperand, secondOperand);

            //Assert (Then)
            Assert.AreEqual(expectedResult, actualResult);
            
        }

        [TestMethod]
        [Priority(1)]
        public void Add0Plus0ShouldReturn0()
        {
            //Arrange (Given)
            Calculator sut = new Calculator();
            int firstOperand = 0;
            int secondOperand = 0;
            int expectedResult = 0;

            //Act (When)
            int actualResult = sut.Add(firstOperand, secondOperand);

            //Assert (Then)
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Divide1DividedBy0ShouldThrow()
        {
            //Arrange (Given)
            Calculator sut = new Calculator();
            int firstOperand = 1;
            int secondOperand = 0;

            //Assert (Then)
            Assert.ThrowsException<DivideByZeroException>(() => {
                //Act (When)
                int actualResult = sut.Divide(firstOperand, secondOperand);
            });
            
        }
    }
}
