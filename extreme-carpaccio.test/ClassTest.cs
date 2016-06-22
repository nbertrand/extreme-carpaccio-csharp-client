using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace extreme_carpaccio.test
{
    public class Test
    {
        [Test]
        public void DoSometing()
        {
            Assert.IsFalse(false);
            //Assert.That(true,Is.False);
        }
    }
}
