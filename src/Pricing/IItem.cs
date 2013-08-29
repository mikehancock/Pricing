using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing
{
    public interface IItem
    {
        string Sku { get; set; }
        decimal Rrp { get; set; }
        decimal UnitCost { get; set; }
        decimal SalesRank { get; set; }
    }
}
