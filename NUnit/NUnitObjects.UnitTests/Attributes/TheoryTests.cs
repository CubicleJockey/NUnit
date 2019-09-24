using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NUnitObjects.UnitTests.Attributes
{
	/// <summary>
	/// A Theory is a special type of test, used to verify a general statement about the system under development.
	/// Normal tests are example-based. That is, the developer supplies one or more examples of inputs and expected 
	/// outputs either within the code of the test or - in the case of Parameterized Tests - as arguments to the 
	/// test method. A theory, on the other hand, makes a general statement that all of its assertions will pass 
	/// for all arguments satisfying certain assumptions.
	/// </summary>
    [TestFixture]
    public class TheoryTests
    {
		[DatapointSource]
		public IEnumerable<double> dataPoints;

        public TheoryTests()
        {
            dataPoints = new[] { 0.0, 1.0, -1.0, 42.0 };
        }
        
		/// <summary>
		/// Given a non-negative number, the square root of that number is always non-negative and, 
		/// when multiplied by itself, gives the original number.
		/// </summary>
		/// <param name="number">Number.</param>
		[Theory, Ignore("Got to fix this.")]
		public void SquareRootsDefinition(double number)
		{
			Assume.That(number >= 0.0);

			var square = Math.Sqrt(number);

			Assert.That(square >= 0.0);
			Assert.That(square * square, Is.EqualTo(number).Within(0.00001));
		}
    }
}
