using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pos.UnitTests
{
    [TestClass]
    public class SalesTaxCalculatorTests
    {
        [TestMethod]
        public void MichiganUsesSixPercentTaxRate()
        {
            // Arrange
            State state = State.MI;
            decimal amount = 100;

            SalesTaxCalculator calculator = new SalesTaxCalculator();

            // Act
            decimal result = calculator.Calculate(amount, state);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void IllinoisUsesSevenPercentTaxRate()
        {
            // Arrange
            State state = State.IL;
            decimal amount = 100;

            SalesTaxCalculator calculator = new SalesTaxCalculator();

            // Act
            decimal result = calculator.Calculate(amount, state);

            // Assert
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void NewYorkUsesSevenPercentTaxRate()
        {
            // Arrange
            State state = State.NY;
            decimal amount = 100;

            SalesTaxCalculator calculator = new SalesTaxCalculator();

            // Act
            decimal result = calculator.Calculate(amount, state);

            // Assert
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void TennesseeUsesElevenPercentTaxRate()
        {
            // Arrange
            State state = State.TN;
            decimal amount = 1;

            SalesTaxCalculator calculator = new SalesTaxCalculator();

            // Act
            decimal result = calculator.Calculate(amount, state);

            // Assert
            Assert.AreEqual(0.11M, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InvalidStateThrowsException()
        {
            // Arrange
            State state = (State)(-1);
            decimal amount = 1;

            SalesTaxCalculator calculator = new SalesTaxCalculator();

            // Act
            decimal result = calculator.Calculate(amount, state);
        }
    }
}
