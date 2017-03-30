using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NUnitObjects.Objects
{
    public class ExceptionThrower
    {
        private readonly Random random;
        public readonly ICollection<Type> ExceptionTypes;

        public ExceptionThrower()
        {
            random = new Random();
            ExceptionTypes = new[]
            {
                typeof(NullReferenceException),
                typeof(NotImplementedException),
                typeof(ArgumentException)
            };
        }

        public void SomeException() => throw new NotImplementedException("Oh noes n' stuff.");

        public async Task SomeExceptionAsync()
        {
            await DoSomething();
        }

        public void ThrowRandomException()
        {
            var number = random.Next(3);
            switch (number)
            {
                case 1:
                    throw new NullReferenceException("Thingy");
                case 2:
                    throw new NotImplementedException("Oh noes n' stuff.");
                case 3:
                    throw new ArgumentException("Something");
            }
        }

        #region Helper Methods

        private static Task DoSomething()
        {
            var task = new Task(() =>
            {
                Thread.Sleep(2000);
                throw new TimeoutException("Taking to long or something like that.");
            });

            task.Start();

            return task;
        }

        #endregion Helper Methods
    }
}