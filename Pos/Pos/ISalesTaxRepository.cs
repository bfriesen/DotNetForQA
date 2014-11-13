using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos
{
    public interface ISalesTaxRepository
    {
        decimal GetTaxRate(State state);
    }
}
