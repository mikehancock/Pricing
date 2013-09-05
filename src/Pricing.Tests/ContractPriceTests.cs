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
    public class ContractPriceTests
    {
        private PriceRuleBuilder _priceBuilder = new PriceRuleBuilder();
        private ItemBuilder _itemBuilder = new ItemBuilder();
        private Mock<ICustomer> _customer = new Mock<ICustomer>();

        [Test]
        public void ContractPriceShouldOverrideDefaultPriceTest()
        {
            _priceBuilder.AddDefaultPriceRule("33333", 20.99m).AddContractPrice("33333", 15.99m, "AA11AA");
            var engine = new Engine(_priceBuilder.Rules);
            _itemBuilder.AddItem("33333", 3.99m, 1);
            _customer.Setup(c => c.Reference).Returns("AA11AA");

            var actual = engine.ApplyRules(_itemBuilder.Items, _customer.Object);
            
            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(15.99m, actual.First().Price);
        }
    }
}
