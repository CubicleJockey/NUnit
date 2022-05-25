using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnitObjects.Objects;

namespace NUnitObjects.UnitTests.Constraints
{
    [TestFixture]
    public class CollectionOrdering
    {
        [Test]
        public void PropertyBasedOrdering()
        {
            var letters = new[] { "x", "xx", "xxx" };

            const string property = nameof(string.Length);

            Assert.That(letters, Is.Ordered.By(property));
            Assert.That(letters, Is.Not.Ordered.Descending.By(property));
        }

        [Test]
        public void MultiplePropertyBasedOrdering()
        {
            IList<Item> items = new List<Item>
            {
                new(){ PropertyA = 3, PropertyB = 66 },
                new(){ PropertyA = 13, PropertyB = 12 },
                new(){ PropertyA = 22, PropertyB = 90 }
            };

            var orderedItems = items.OrderBy(item => item.PropertyA)
                                    .ThenBy(item => item.PropertyB);

            Assert.That(orderedItems, Is.Ordered.By(nameof(Item.PropertyA)).Then.By(nameof(Item.PropertyB)));

            var anotherOrderedItems = items.OrderBy(item => item.PropertyB)
                                          .ThenBy(item => item.PropertyA);

            Assert.That(anotherOrderedItems, Is.Ordered.By(nameof(Item.PropertyB)).Then.By(nameof(Item.PropertyA)));
        }
    }
}