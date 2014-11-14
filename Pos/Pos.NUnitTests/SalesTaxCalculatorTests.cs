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
        [Test]
        public void TheAmountIsMultipliedByTheTaxRateReturnedByTheSalesTaxRepository()
        {
            ISalesTaxRepository salesTaxRepository = new FakeSalesTaxRepository();

            SalesTaxCalculator calculator = new SalesTaxCalculator(salesTaxRepository);

            decimal taxAmount = calculator.Calculate(100M, State.MI);

            Assert.That(taxAmount, Is.EqualTo(6M));
        }

        public class FakeSalesTaxRepository : ISalesTaxRepository
        {
            public decimal GetTaxRate(State state)
            {
                return 0.06M;
            }
        }
    }
}
