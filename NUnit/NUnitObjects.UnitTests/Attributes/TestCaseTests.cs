using static System.Console;
using NUnit.Framework;
using NUnitObjects.Models;

namespace NUnitObjects.UnitTests.Attributes
{
	/// <summary>
	/// TestCaseAttribute serves the dual purpose of marking a method with parameters as a test method and 
	/// providing inline data to be used when invoking that method. Here is an example of a test being run three times, 
	/// with three different sets of data
	/// </summary>
	[TestFixture]
	public class TestCaseTests
	{
		[TestCase(12, 3, 4)]
		[TestCase(12, 2, 6)]
		[TestCase(12, 4, 3)]
		public void DivideTests(int numerator, int denominator, int quotient)
		{
			Assert.AreEqual(quotient, numerator / denominator);
		}

		[TestCase(12, 3, ExpectedResult = 4)]
		[TestCase(12, 2, ExpectedResult = 6)]
		[TestCase(12, 4, ExpectedResult = 3)]
		public int DivideTestSimplified(int numerator, int demoniator)
		{
			return (numerator / demoniator);
		}

		[TestCase(IgnoreReason = "Because I hate this test.")]
		public void IgnoreAndReasonTests()
		{
			//Ignored
		}

		[TestCase(IncludePlatform = "Win95, Win98, WinME, Win7, Win10, Net-2.0, Unix, Linux")]
		public void IncludeThesePlatforms()
		{
			//platforms this is valid on
		}

		[TestCase(ExcludePlatform = "Mono, Mono-1.0, Mono-2.0")]
		public void ExcludeThesePlatforms()
		{
			//Excluded Platforms
		}

		/// <summary>
		/// You can currently only have one TestOf attribute per fixture or test.
		/// </summary>
		[TestCase(TestOf = typeof(Account))]
		public void TestOf()
		{
			//This test is only for Account
			WriteLine($"This test is set to only Test {nameof(Account)}");
		}
	}
}
