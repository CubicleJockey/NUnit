using System.Collections.Generic;
using NUnit.Framework;

namespace NUnitObjects.UnitTests.Constraints
{
    [TestFixture]
    public class AllItems
    {
        private readonly IEnumerable<object> multiTypeCollection;
        private readonly IEnumerable<int> sameTypeCollection;

        public AllItems()
        {
            multiTypeCollection = new object[] { 1, 2, 4, "string", 'B', true, false, 14.4 };
            sameTypeCollection = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        [Test]
        public void IsAll()
        {
            Assert.That(multiTypeCollection, Is.All.Not.Null);
            Assert.That(sameTypeCollection, Is.All.InstanceOf<int>());
            Assert.That(sameTypeCollection, Is.All.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void HasAll()
        {
            Assert.That(multiTypeCollection, Has.All.Not.Null);

            Assert.That(sameTypeCollection, Has.All.InstanceOf<int>());
            Assert.That(sameTypeCollection, Has.All.GreaterThanOrEqualTo(1));
        }
    }
}