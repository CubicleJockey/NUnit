using NUnit.Framework;

namespace NUnitObjects.UnitTests.Constraints
{
    [TestFixture]
    public class AssignableFrom
    {
        [Test]
        public void Basic()
        {
            const string THINGY = "Thingy";
            const int NUMBER = 13;

            Assert.That(THINGY, Is.AssignableFrom(typeof(string)));
            Assert.That(THINGY, Is.AssignableFrom<string>());

            Assert.That(NUMBER, Is.Not.AssignableFrom(typeof(string)));
            Assert.That(NUMBER, Is.Not.AssignableFrom<string>());
        }
    }
}