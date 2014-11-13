using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos
{
    public class SalesTaxCalculator
    {
        private ISalesTaxRepository _salesTaxRepository;

        public SalesTaxCalculator(ISalesTaxRepository salesTaxRepository)
        {
            _salesTaxRepository = salesTaxRepository;
        }

        public decimal Calculate(decimal amount, State state)
        {
            decimal taxRate;

            taxRate = _salesTaxRepository.GetTaxRate(state);

            return amount * taxRate;
        }
    }
}
