using System;
using Xunit;

namespace ClassLibraryStandard.UnitTestsXUnit
{
    public class CalculatorTests
    {
        [Fact]
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
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
