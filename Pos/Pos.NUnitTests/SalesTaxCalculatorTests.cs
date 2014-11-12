using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.NUnitTests
{
    [TestFixture]
    public class SalesTaxCalculatorTests
    {
        [TestCase(State.MI, 6)]
        [TestCase(State.IL, 7)]
        [TestCase(State.NY, 7)]
        [TestCase(State.TN, 11)]
        public void StatesUseTheAppropriateTaxRate(State state, int expectedTaxAmount)
        {
            // Arrange
            decimal amount = 100;

            SalesTaxCalculator calculator = new SalesTaxCalculator();

            // Act
            decimal result = calculator.Calculate(amount, state);

            // Assert
            Assert.That(result, Is.EqualTo(expectedTaxAmount));
        }

        [Test]
        public void InvalidStateThrowsException()
        {
            // Arrange
            State state = (State)(-1);
            decimal amount = 1;

            SalesTaxCalculator calculator = new SalesTaxCalculator();

            // Act
            Assert.Throws(typeof(Exception), () => calculator.Calculate(amount, state));
        }
    }
}
