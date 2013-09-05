using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Pricing.Tests
{
    [TestFixture]
    public class DefaultPriceTests
    {
        private Mock<ICustomer> _customer = new Mock<ICustomer>();

        [Test]
        public void SimpleDefaultPriceTest()
        {
            var priceBuilder = new PriceRuleBuilder().AddDefaultPriceRule("33333", 20.99m);
            var engine = new Engine(priceBuilder.Rules);
            var itemBuilder = new ItemBuilder().AddItem("33333", 3.99m, 1);

            var actual = engine.ApplyRules(itemBuilder.Items, _customer.Object);

            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(5.19m, actual.First().Price);
        }

        [Test]
        public void DefaultPriceAppliedWhenOtherNonApplicationRulesArePresentTest()
        {
            var priceBuilder = new PriceRuleBuilder().AddDefaultPriceRule("33333", 20.99m).AddContractPrice("11111", 12.99m, "111111");
            var engine = new Engine(priceBuilder.Rules);
            var itemBuilder = new ItemBuilder().AddItem("33333", 3.99m, 1m);

            var actual = engine.ApplyRules(itemBuilder.Items, _customer.Object);

            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(5.19m, actual.First().Price);
        }
    }
}
