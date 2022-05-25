using NUnit.Framework;
using System.Linq;

namespace NUnitObjects.UnitTests.Constraints
{
    [TestFixture]
    public class And
    {
        [Test]
        public void BasicAdd() => Assert.That(2.3, Is.GreaterThan(2.0).And.LessThan(3.0));

        [Test]
        public void CollectionAdds()
        {
            var numbers = Enumerable.Range(1, 50);

            Assert.That(numbers, Is.Ordered.And.All.Positive);

            var negativeNumbers = new[] { -1, -2, -3 };

            Assert.That(negativeNumbers, Is.Unique.And.All.Negative);
        }
    }
}