using System.Collections.Generic;
using NUnit.Framework;

namespace NUnitObjects.UnitTests.Constraints
{
    [TestFixture]
    public class CollectionContains
    {
        [Test]
        public void Basic()
        {
            IEnumerable<object> items = new object[] { 1, 2, 3, 4, 'a', 'b', 'c', "Word", "Thingy" };

            Assert.That(items, Has.Member(3));
            Assert.That(items, Has.Member('c'));
            Assert.That(items, Has.Member("Thingy"));

            Assert.That(items, Has.No.Member('z'));
            Assert.That(items, Has.No.Member("No Here"));
            Assert.That(items, Has.No.Member(999));

            Assert.That(items, Contains.Item('b'));
            Assert.That(items, Contains.Item(1));
            Assert.That(items, Contains.Item("Thingy"));

            Assert.That(items, Does.Contain(4));
            Assert.That(items, Does.Contain('a'));
            Assert.That(items, Does.Contain("Word"));
        }
    }
}