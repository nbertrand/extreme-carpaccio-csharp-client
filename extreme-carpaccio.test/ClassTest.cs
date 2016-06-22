using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using xCarpaccio.client;

namespace extreme_carpaccio.test
{
    public class Test
    {
        [Test]
        public void TestLength()
        {
            var order = new Order { Quantities = new [] {1, 2}, Prices = new [] {1.2m}};
            var bill = BillCalculator.CalculateBill(order);
            Assert.That(bill, Is.Null);
            //Assert.That(true,Is.False);
        }
    }
}
