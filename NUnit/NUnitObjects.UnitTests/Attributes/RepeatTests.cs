using System;
using NUnit.Framework;

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
            Console.WriteLine($"Success run number {++count}");
        }

        [Test]
        [Repeat(REPEAT)]
        public void RepeatedTests_Stop()
        {
            const int FAILON = 3;
            //test run increment
            count = ++count;

            if(count == FAILON)
            {
                Assert.Fail($"Repeat Failure, no tests past {FAILON}");
            }
            Console.WriteLine($"Success run number {count}");
        }
    }
}
