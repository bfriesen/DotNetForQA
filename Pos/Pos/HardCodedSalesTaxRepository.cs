using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos
{
    public class HardCodedSalesTaxRepository : ISalesTaxRepository
    {
        public decimal GetTaxRate(State state)
        {
            switch (state)
            {
                case State.MI:
                    return 0.06M;
                case State.IL:
                case State.NY:
                    return 0.07M;
                case State.TN:
                    return 0.11M;
                default:
                    throw new Exception("bad state: " + state);
            }
        }
    }
}
