using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Rules
{
    public class MultiBuy : IPriceRule
    {
        public List<string> Skus { get; set; }
        public int Priority { get; set; }

        public bool CanApply(IEnumerable<IItem> items, ICustomer customer)
        {
            return Skus.All(s => items.Any(i => i.Sku == s));
        }

        public void Apply(IEnumerable<IItem> items)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IItem> AppliedItems { get; private set; }

        public decimal Price { get; set; }
    }
}
