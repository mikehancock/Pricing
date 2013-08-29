using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Rules
{
    public class DefaultPrice : IPriceRule
    {
        public int Priority { get; set; }

        public decimal Price { get; set; }

        public bool CanApply(IEnumerable<IItem> items, ICustomer customer)
        {
            return true;
        }

        public string Sku { get; set; }

        public void Apply(IEnumerable<IItem> items)
        {
            AppliedItems = new List<IItem>() {items.First()};
        }

        public IEnumerable<IItem> AppliedItems { get; private set; }
    }
}
