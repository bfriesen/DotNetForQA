using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pos.UnitTests
{
    [TestClass]
    public class SalesTaxCalculatorTests
    {
        [TestMethod]
        public void TheAmountIsMultipliedByTheTaxRateReturnedByTheSalesTaxRepository()
        {
            ISalesTaxRepository salesTaxRepository = new FakeSalesTaxRepository();

            SalesTaxCalculator calculator = new SalesTaxCalculator(salesTaxRepository);

            decimal taxAmount = calculator.Calculate(100M, State.MI);

            Assert.AreEqual(6M, taxAmount);
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
