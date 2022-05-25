using System;
using NUnit.Framework;

using static System.Console;
using static NUnit.Framework.Assert;

namespace NUnitObjects.UnitTests.Attributes
{
    [TestFixture]
    public class RepeatTests
    {
        private const int REPEAT = 5;
        private static int count = 0;

        [Test]
        [Repeat(REPEAT)]
        public void RepeatedTests_Success()
        {
            WriteLine($"Success run number {++count}");
        }

        [Test]
        [Repeat(REPEAT)]
        public void RepeatedTests_Stop()
        {
            const int FAIL_ON = 3;
            //test run increment
            count = ++count;

            if(count == FAIL_ON) { Fail($"Repeat Failure, failed on step {count} of {REPEAT}"); }
            WriteLine($"Success run number {count}");
        }
    }
}
