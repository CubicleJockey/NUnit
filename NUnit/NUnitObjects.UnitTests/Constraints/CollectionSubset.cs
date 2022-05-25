using NUnit.Framework;

namespace NUnitObjects.UnitTests.Constraints
{
    [TestFixture]
    public class CollectionSubset
    {
        [Test]
        public void Basic()
        {
            var numbers = new[] { 1, 3, 5 };
            Assert.That(numbers, Is.SubsetOf(new[]{ 1, 2, 3, 4, 5 }));
        }
    }
}