using NUnit.Framework;
using System.Threading;

namespace NUnitObjects.UnitTests.Constraints
{
    [TestFixture]
    public class Deplayed
    {
        [Test]
        public void Basic()
        {
            Assert.That(UpdateEachSecond, Is.EqualTo(4).After(5).Seconds);
        }

        [Test]
        [Description("Allow max run-time to be 5 minutes but check every second (1000ms), stop early when condition is met.")]
        public void Polling()
        {
            Assert.That(UpdateEachSecond, Is.EqualTo(4).After(5).Minutes.PollEvery(1000));
        }

        #region Helper Methods

        private static int UpdateEachSecond()
        {
            var count = 0;
            for (var i = 0; i <= 4; i++)
            {
                Thread.Sleep(1000);
                count = i;
            }
            return count;
        }

        #endregion Helper Methods
    }
}
