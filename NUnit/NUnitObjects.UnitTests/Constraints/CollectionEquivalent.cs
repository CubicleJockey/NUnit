using System.Collections.Generic;
using NUnit.Framework;

namespace NUnitObjects.UnitTests.Constraints
{
    [TestFixture]
    public class CollectionEquivalent
    {
        [Test]
        public void Basic()
        {
            IEnumerable<int> EXPECTED = new[] { 1, 2, 3 };
            IEnumerable<int> NOTEXPECTED = new[] { 1, 2, 3, 4};
            IEnumerable<int> numbers = new[] { 1, 2, 3 };

            Assert.That(EXPECTED, Is.EquivalentTo(numbers));
            Assert.That(NOTEXPECTED, Is.Not.EquivalentTo(numbers));
        }
    }
}