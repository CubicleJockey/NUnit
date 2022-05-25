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

        public static async Task SomeExceptionAsync()
        {
            await DoSomething();
        }

        public void ThrowRandomException()
        {
            var number = random.Next(3);
            throw number switch
            {
                1 => new NullReferenceException("Thingy"),
                2 => new NotImplementedException("Oh noes n' stuff."),
                3 => new ArgumentException("Something"),
                _ => new Exception("Some unknown exception.")
            };
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