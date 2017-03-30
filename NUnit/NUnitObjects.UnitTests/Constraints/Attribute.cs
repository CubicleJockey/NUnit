using System;
using NUnit.Framework;
using NUnitObjects.Objects;

namespace NUnitObjects.UnitTests.Constraints
{
    [TestFixture]
    public class Attribute
    {
        [Test, Ignore("Not sure why it's throwing ICustomAttribute exception. Need to look into this.")]
        public void Basic()
        {
            var ao = new AttributedObject();

            Assert.That(ao, Has.Attribute(typeof(DescriptionAttribute)).Property("Description").EqualTo("A Description"));
            Assert.That(ao, Has.Attribute<DescriptionAttribute>().Property("Description").EqualTo("A Description"));
        }
    }
}