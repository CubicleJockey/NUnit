using System;
using NUnit.Framework;

namespace NUnitObjects.UnitTests.Assertions
{
    [TestFixture]
    public class Warnings
    {
        private const int WARNON = 5;

        [Test]
        public void WarningMessage()
        {
            Assert.Warn("This is a warning.");
        }

        [Test]
        public void WarnReversedConditions()
        {
            //local function with expression body
            int AddTwoPlusTwo() => 2 + 2;

            //1984 style
            Warn.If(AddTwoPlusTwo() != WARNON);
            Warn.If(AddTwoPlusTwo(), Is.Not.EqualTo(WARNON));
            Warn.If(AddTwoPlusTwo, Is.EqualTo(WARNON).After(2000));
        }

        [Test]
        public void WarnWithOriginalCondition()
        {
            //local function
            int AddTwoPlusTwo()
            {
                return 2 + 2;
            }

            //1984 style
            Warn.Unless(AddTwoPlusTwo() == WARNON);
            Warn.Unless(AddTwoPlusTwo(), Is.EqualTo(WARNON));
            Warn.Unless(AddTwoPlusTwo, Is.EqualTo(WARNON));
        }
    }
}