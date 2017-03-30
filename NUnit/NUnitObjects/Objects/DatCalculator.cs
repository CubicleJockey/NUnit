using System;

namespace NUnitObjects.Objects
{
    public class DatCalculator
    {
        private const int CONVERTER = 100;
        private readonly Random random;

        public DatCalculator()
        {
            random = new Random();
        }

        public (double RealPart, double ImaginaryPart) SomeCalculation()
        {
            var real = random.NextDouble() * CONVERTER;
            var imaginary = random.NextDouble() * CONVERTER;

            return (real, imaginary);
        }
    }
}