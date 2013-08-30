using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricing.Rules;

namespace Pricing.Tests
{
    internal class PriceRuleBuilder
    {
        private IList<IPriceRule> _rules = new List<IPriceRule>();
        internal PriceRuleBuilder AddDefaultPriceRule(string sku, decimal price)
        {
            _rules.Add(new DefaultPrice() {Priority = 10, Sku = sku, Price = price});
            return this;
        }

        internal PriceRuleBuilder AddContractPrice(string sku, decimal price, string customerReference)
        {
            _rules.Add(new ContractPrice() {Priority = 9, Sku = sku, CustomerReference = customerReference, Price = price});
            return this;
        }

        internal PriceRuleBuilder AddBogof(string sku, decimal price)
        {
            _rules.Add(new BuyOneGetOneFree() {Sku = sku, Price = price});
            return this;
        }

        internal IEnumerable<IPriceRule> Rules
        {
            get { return _rules; }
        } 
    }
}
