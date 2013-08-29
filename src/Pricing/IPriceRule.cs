using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pricing
{
    public interface IPriceRule
    {
        int Priority { get; set; }
        bool CanApply(IEnumerable<IItem> items, ICustomer customer);
        void Apply(IEnumerable<IItem> items);
        IEnumerable<IItem> AppliedItems { get; }
        decimal Price { get; set; }
    }
}
