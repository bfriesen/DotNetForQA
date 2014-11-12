using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos
{
    public class SalesTaxCalculator
    {
        private readonly decimal _taxRate;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesTaxCalculator"/> class.
        /// </summary>
        /// <param name="taxRatePercent">
        /// The tax rate percent. For example, 7.25M for 7.25%. Not 0.0725M.
        /// </param>
        public SalesTaxCalculator(decimal taxRatePercent)
        {
            _taxRate = taxRatePercent / 100;
        }

        public decimal Calculate(decimal amount)
        {
            return amount * _taxRate;
        }
    }
}
