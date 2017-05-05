using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Shop.Test.DbContext
{
    [TestFixture]
    class DbContextTest
    {
        [Test]
        public void TestContext()
        {
            //Arrange
            var expected = "Allah";
            var result = false;
            //Act
            result = expected.CompareTo("Allah") > -1;
            //Assert
            Assert.IsTrue(result);

        }
    }
}
