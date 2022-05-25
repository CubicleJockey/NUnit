using NUnit.Framework;
using NUnitObjects.Exceptions;
using NUnitObjects.Models;

namespace NUnitObjects.UnitTests
{
    [TestFixture]
    public class AccountTests
    {
        #region Constructor Tests

        [Test]
        public void DefaultConstructor()
        {
            const string ACCOUNT_NAME = "A";
            var account = new Account(ACCOUNT_NAME);

            Assert.IsNotNull(account);
            Assert.IsInstanceOf<Account>(account);
            Assert.AreEqual(ACCOUNT_NAME, account.AccountName);
            Assert.AreEqual(0, account.Balance);
        }

        [Test]
        public void BalanceConstructor()
        {
            const string ACCOUNT_NAME = "Rammstein";
            var startingBalance = new decimal(102000.14);
            var account = new Account(ACCOUNT_NAME, startingBalance);

            Assert.IsNotNull(account);
            Assert.IsInstanceOf<Account>(account);
            Assert.AreEqual(ACCOUNT_NAME, account.AccountName);
            Assert.AreEqual(startingBalance, account.Balance);
        }

        #endregion Constructor Tests

        #region Methods Tests

        [Test, Description("No starting balance")]
        public void Deposit()
        {
            var account = new Account("A");
            Assert.IsNotNull(account);
            Assert.AreEqual(0m, account.Balance);
      
            account.Deposit(100m);
            Assert.AreEqual(100m, account.Balance);
        }

        [Test, Description("Starting balance")]
        public void Deposit_StartingBalance()
        {
            var account = new Account("A", 1000m);
            Assert.IsNotNull(account);
            Assert.AreEqual(1000m, account.Balance);

            account.WithDraw(125m);
            Assert.AreEqual(875m, account.Balance);
        }

        [Test]
        public void WithDraw()
        {
            var account = new Account("A", 500m);
            account.WithDraw(400m);
            Assert.AreEqual(100m, account.Balance);
        }

        [Test, Description("WithDrawl insufficient funds")]
        public void WithDraw_InsufficientFunds()
        {
            var account = new Account("A");
            Assert.Throws<InsufficientFundsException>(() => account.WithDraw(50m));
        }

        [Test]
        public void TransferWithInsufficientFunds()
        {
            var source = new Account("A");
            var destination = new Account("B", 1000m);
            Assert.Throws<InsufficientFundsException>(() => source.TransferFunds(destination, 100m));
        }

        [Test]
        public void TransferFunds()
        {
            var source = new Account("A", 2000m);
            var destination = new Account("B", 150m);

            source.TransferFunds(destination, 100m);

            Assert.AreEqual(1900m, source.Balance);
            Assert.AreEqual(250m, destination.Balance);
        }

        [Test, Ignore("This is a test that will be ignored by the test runner")]
        public void ImIgnored()
        {
            //Nothing to do ignored.
        }

        #endregion Methods Tests
    }
}
