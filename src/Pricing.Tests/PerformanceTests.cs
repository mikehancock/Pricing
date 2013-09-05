using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Pricing.Tests
{
    [TestFixture]
    public class PerformanceTests
    {
        private PriceRuleBuilder _priceBuilder = new PriceRuleBuilder();
        private ItemBuilder _itemBuilder = new ItemBuilder();
        private Mock<ICustomer> _customer = new Mock<ICustomer>();

        [Test]
        public void PerformanceTest()
        {
            for (var i = 0; i < 15000; i++)
            {
                _priceBuilder.AddDefaultPriceRule(i.ToString(), 20.99m);
                _priceBuilder.AddContractPrice(i.ToString(), 15.99m, "AAAAAA");
            }
            _priceBuilder.AddBogof("11111", 20.99m);
            var engine = new Engine(_priceBuilder.Rules);

            var items = _itemBuilder.AddItem("52345", 5.99m, 1).AddItem("33333", 3.99m, 1).AddItem("44444", 15.99m, 1).Items;

            var timer = new Stopwatch();
            timer.Start();
            engine.ApplyRules(items, _customer.Object);
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);
            
            Assert.IsTrue(timer.ElapsedMilliseconds < 300);
        }
    }
}
