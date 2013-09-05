using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Tests
{
    internal class ItemBuilder
    {
        private IList<IItem> _items = new List<IItem>();

        internal ItemBuilder AddItem(string sku, decimal unitCost, decimal salesRank)
        {
            _items.Add(new TestItem() { Rrp = 10.99m, Sku = sku, UnitCost = unitCost, SalesRank = salesRank});
            return this;
        }

        internal IEnumerable<IItem> Items
        {
            get { return _items; }
        } 
    }

    internal class TestItem : IItem
    {

        public string Sku { get; set; }

        public decimal Rrp { get; set; }

        public decimal UnitCost { get; set; }

        public decimal SalesRank { get; set; }
    }
}
