using System;
using NUnit.Framework;

namespace NUnitObjects.UnitTests.Assertions
{
    [TestFixture]
    public class Warnings
    {
        private const int WARN_ON = 5;

        [Test]
        public void WarningMessage()
        {
            Assert.Warn("This is a warning.");
        }

        [Test]
        public void WarnReversedConditions()
        {
            //local function with expression body
            static int AddTwoPlusTwo() => 2 + 2;

            //1984 style
            Warn.If(AddTwoPlusTwo() != WARN_ON);
            Warn.If(AddTwoPlusTwo(), Is.Not.EqualTo(WARN_ON));
            Warn.If(AddTwoPlusTwo, Is.EqualTo(WARN_ON).After(2000));
        }

        [Test]
        public void WarnWithOriginalCondition()
        {
            //local function
            static int AddTwoPlusTwo() => 2 + 2;

            //1984 style
            Warn.Unless(AddTwoPlusTwo() == WARN_ON);
            Warn.Unless(AddTwoPlusTwo(), Is.EqualTo(WARN_ON));
            Warn.Unless(AddTwoPlusTwo, Is.EqualTo(WARN_ON));
        }
    }
}