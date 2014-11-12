using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos
{
    public class SalesTaxCalculator
    {
        public decimal Calculate(decimal amount, State state)
        {
            decimal taxRate;

            switch (state)
            {
                case State.MI:
                    taxRate = 0.06M;
                    break;
                case State.IL:
                case State.NY:
                    taxRate = 0.07M;
                    break;
                case State.TN:
                    taxRate = 0.11M;
                    break;
                default:
                    throw new Exception("bad state: " + state);
            }

            return amount * taxRate;
        }
    }
}
