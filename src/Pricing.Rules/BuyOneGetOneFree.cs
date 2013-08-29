using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Rules
{
    public class BuyOneGetOneFree : IPriceRule
    {
        public string Sku { get; set; }
        public int Priority { get; set; }

        public bool CanApply(IEnumerable<IItem> items, ICustomer customer)
        {
            return items.Count(i => i.Sku == Sku) >= 2;
        }

        public void Apply(IEnumerable<IItem> items)
        {
            AppliedItems = items.Where(i => i.Sku == Sku).Take(2);
        }

        public IEnumerable<IItem> AppliedItems { get; private set; }

        public decimal Price { get; set; }
    }
}
