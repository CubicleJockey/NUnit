using NUnit.Framework;

namespace NUnitObjects.UnitTests.Constraints
{
    [TestFixture]
    public class CollectionSuperset
    {
        [Test]
        public void Basic()
        {
            var alpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            Assert.That(alpha, Is.SupersetOf(new[]{'b', 'j', 'r'}));
        }
    }
}
