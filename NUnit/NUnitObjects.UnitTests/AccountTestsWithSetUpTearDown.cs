using System;
using NUnit.Framework;
using NUnitObjects.Repository;
using NUnitObjects.UnitTests.Mocks;

namespace NUnitObjects.UnitTests
{
    [TestFixture]
    public class AccountTestSetupAndTeardown
    {
        private IAccountRepository accountRepository;

        #region Setup/TearDown

        [SetUp]
        public void Setup()
        {
            accountRepository = new MockAccountRespository();
        }

        [TearDown]
        public void TearDown()
        {
            accountRepository = null;
            GC.Collect();
        }

        #endregion Setup/TearDown

        [Test, Description("This test is dependent on the actions of Setup")]
        public void TestShowingSetUpWorked()
        {
            var account = accountRepository.GetAccount("D");
            Assert.IsNotNull(account);
            Assert.AreEqual("D", account.AccountName);
            Assert.AreEqual(30m, account.Balance);
        }
    }
}
