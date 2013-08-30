using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing
{
    public class Engine
    {
        private readonly IEnumerable<IPriceRule> _priceRules;
 
        public Engine(IEnumerable<IPriceRule> priceRules)
        {
            _priceRules = priceRules.OrderBy(r => r.Priority);
        }

        public IEnumerable<IPriceRule> ApplyRules(IEnumerable<IItem> items, ICustomer customer)
        {
            return ApplyRules(items, customer, new List<IPriceRule>());
        }

        private IEnumerable<IPriceRule> ApplyRules(IEnumerable<IItem> items, ICustomer customer, IList<IPriceRule> appliedRules)
        {
            var toApply = _priceRules.FirstOrDefault(r => r.CanApply(items, customer));

            if (toApply != null)
            {
                toApply.Apply(items);
                appliedRules.Add(toApply);
                var remainingitems = items.Except(toApply.AppliedItems);
                if (remainingitems.Any())
                    return ApplyRules(remainingitems, customer, appliedRules);
            }

            return appliedRules;
        }
    }
}
