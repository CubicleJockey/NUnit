﻿using System.Collections.Generic;
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

            const string property = nameof(letters.Length);

            Assert.That(letters, Is.Ordered.By(property));
            Assert.That(letters, Is.Not.Ordered.Descending.By(property));
        }

        [Test]
        public void MultiplePropertyBasedOrdering()
        {
            IList<Item> items = new List<Item>
            {
                new Item{ PropertyA = 3, PropertyB = 66},
                new Item{ PropertyA = 13, PropertyB = 12 },
                new Item{ PropertyA = 22, PropertyB = 90 }
            };

            var orderedItems = items.OrderBy(item => item.PropertyA)
                                    .ThenBy(item => item.PropertyB);

            Assert.That(orderedItems, Is.Ordered.By(nameof(Item.PropertyA)).Then.By(nameof(Item.PropertyB)));

            var anotherOrdredItems = items.OrderBy(item => item.PropertyB)
                                          .ThenBy(item => item.PropertyA);

            Assert.That(anotherOrdredItems, Is.Ordered.By(nameof(Item.PropertyB)).Then.By(nameof(Item.PropertyA)));
        }
    }
}