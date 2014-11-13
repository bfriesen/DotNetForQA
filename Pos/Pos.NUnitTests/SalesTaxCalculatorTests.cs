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
        [TestCase(100, State.MI, 6, TestName = "MichiganUsesSixPercentTaxRate")]
        [TestCase(200, State.IL, 14, TestName = "IllinoisUsesSevenPercentTaxRate")]
        [TestCase(100, State.NY, 7, TestName = "NewYorkUsesSevenPercentTaxRate")]
        [TestCase(300, State.TN, 33, TestName = "TennesseeUsesElevenPercentTaxRate")]
        public void StatesUseTheAppropriateTaxRate(int amount, State state, int expectedTaxAmount)
        {
            // Arrange
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
            State invalidState = (State)(-1);

            SalesTaxCalculator calculator = new SalesTaxCalculator();

            // Act / Assert
            Assert.That(() => calculator.Calculate(100, invalidState), Throws.Exception);
        }
    }
}
