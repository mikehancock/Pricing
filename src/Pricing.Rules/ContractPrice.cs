using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Rules
{
    public class ContractPrice : IPriceRule
    {
        public string Sku { get; set; }
        public string CustomerReference { get; set; }

        public int Priority { get; set; }
        public decimal Price { get; set; }

        public bool CanApply(IEnumerable<IItem> items, ICustomer customer)
        {
            return items.Any(i => i.Sku == Sku && customer.Reference == CustomerReference);
        }

        public void Apply(IEnumerable<IItem> items)
        {
            AppliedItems = new List<IItem>() {items.Single(i => i.Sku == Sku)};
        }

        public IEnumerable<IItem> AppliedItems { get; private set; }
    }
}
