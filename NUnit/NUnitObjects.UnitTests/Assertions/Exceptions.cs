using System;
using System.Collections;
using NUnit.Framework;
using NUnitObjects.Objects;

namespace NUnitObjects.UnitTests.Assertions
{
    [TestFixture]
    public class Exceptions
    {
        private readonly ExceptionThrower thrower;

        public Exceptions()
        {
            thrower = new ExceptionThrower();
        }

        [Test]
        public void AssertAndCheckException()
        {
            var exception = Assert.Throws<NotImplementedException>(() => thrower.SomeException());

            Assert.IsNotNull(exception);
            Assert.IsInstanceOf<NotImplementedException>(exception);
            Assert.AreEqual("Oh noes n' stuff.", exception.Message);
            Assert.IsNull(exception.InnerException);
        }

        [Test]
        public void AssertAndCheckAsyncException()
        {
            var exception = Assert.ThrowsAsync<TimeoutException>(() => thrower.SomeExceptionAsync());

            Assert.IsNotNull(exception);
            Assert.IsInstanceOf<TimeoutException>(exception);
            Assert.AreEqual("Taking to long or something like that.", exception.Message);
            Assert.IsNull(exception.InnerException);
        }

        [Test]
        public void AssertAnExceptionWasThrown()
        {
            var exception = Assert.Catch(() => thrower.ThrowRandomException());

            Assert.IsNotNull(exception);
        }

        [Test]
        public void AssertAnExceptionWasThrownAsync()
        {
            var exception = Assert.CatchAsync<TimeoutException>(() => thrower.SomeExceptionAsync());

            Assert.IsNotNull(exception);
            Assert.IsInstanceOf<TimeoutException>(exception);
            Assert.AreEqual("Taking to long or something like that.", exception.Message);
            Assert.IsNull(exception.InnerException);
        }
    }
}