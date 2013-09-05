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
    public class BuyOneGetOneFreeTests
    {
        private Mock<ICustomer> _customer = new Mock<ICustomer>();

        [Test]
        public void BogofShouldOverrideDefaultPriceTest()
        {
            var priceBuilder = new PriceRuleBuilder().AddDefaultPriceRule("33333", 20.99m).AddBogof("33333", 20.99m);
            var engine = new Engine(priceBuilder.Rules);
            var itemBuilder = new ItemBuilder().AddItem("33333", 3.99m, 1).AddItem("33333", 3.99m, 1);

            var actual = engine.ApplyRules(itemBuilder.Items, _customer.Object);

            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(2, actual.First().AppliedItems.Count());
            Assert.AreEqual(20.99m, actual.First().Price);
        }
    }
}
