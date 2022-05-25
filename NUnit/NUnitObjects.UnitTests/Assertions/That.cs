using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnitObjects.Objects;

using static System.Console;
using static NUnit.Framework.Assert;

namespace NUnitObjects.UnitTests.Assertions
{
    [TestFixture]
    public class That
    {
        private readonly IEnumerable<int> numbers;

        public That()
        {
            numbers = new[] { 1, 2, 3, 4, 5, 5, 6, 8, 13, 12, -13, -42 };
        }

        [Test]
        public void BasicCollectionThatAssertion()
        {
            That(numbers, Has.Exactly(6).GreaterThan(4));
            That(numbers, Has.Exactly(5).LessThan(4));
            That(numbers, Has.Exactly(2).EqualTo(5));
            That(numbers, Has.Exactly(1).EqualTo(-13));
        }

        [Test]
        public void AreEqualAndThatEquivalence()
        {
            AreEqual(4, 2 + 2);
            That(2 + 2, Is.EqualTo(4));
        }      
        
        /// <summary>
        ///    1. The multiple assert block may contain any arbitrary code, not just asserts.
        ///
        ///    2. Multiple assert blocks may be nested. Failure is not reported until the outermost block exits.
        ///
        ///    3. If the code in the block calls a method, that method may also contain multiple assert blocks.
        ///
        ///    4. The test will be terminated immediately if any exception is thrown that is not handled.
        ///       An unexpected exception is often an indication that the test itself is in error, so it must be
        ///       terminated.
        ///       If the exception occurs after one or more assertion failures have been recorded, those failures will
        ///       be reported along with the terminating exception itself.
        ///
        ///    5.  Assert.Fail is handled just as any other assert failure.
        ///        The message and stack trace are recorded but the test continues to execute until the end of the block.
        ///
        ///    6.  An error is reported if any of the following are used inside a multiple assert block:
        ///
        ///         * Assert.Pass
        ///         * Assert.Ignore
        ///         * Assert.Inconclusive
        ///         * Assume.That
        ///
        ///     7. Use of Warnings (Assert.Warn, Warn.If, Warn.Unless) is permitted inside a multiple assert block.
        ///        Warnings are reported normally along with any failures that occur inside the block.
        /// </summary>
        [Test]
        public void ComplexNumberTest()
        {
            var calculator = new DatCalculator();
            var result = calculator.SomeCalculation();

            Multiple(() =>
            {
                IsNotNull(result);
                IsInstanceOf<ValueTuple<double, double>>(result);
                WriteLine($"RealPart:[{result.RealPart}] - ImaginaryPart:[{result.ImaginaryPart}]");
                That(result.RealPart, Is.InRange(0.0, 100.00), "Real Part");
                That(result.ImaginaryPart, Is.InRange(0.0, 100.00), "Imaginary Part");
            });
        }
    }
}