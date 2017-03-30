using NUnit.Framework;

namespace NUnitObjects.UnitTests.Constraints
{
    [TestFixture]
    public class AssignableTo
    {
        [Test]
        public void Basic()
        {
            const string THINGY = "Thingy";
            const int NUMBER = 6;

            Assert.That(THINGY, Is.AssignableTo(typeof(object)));
            Assert.That(THINGY, Is.AssignableTo<object>());

            Assert.That(NUMBER, Is.Not.AssignableTo(typeof(string)));
            Assert.That(NUMBER, Is.Not.AssignableTo<string>());
        }
    }
}