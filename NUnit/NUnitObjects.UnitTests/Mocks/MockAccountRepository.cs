using System.Collections.Generic;
using System.Linq;
using NUnitObjects.Exceptions;
using NUnitObjects.Models;
using NUnitObjects.Repository;

namespace NUnitObjects.UnitTests.Mocks
{
    public class MockAccountRepository : IAccountRepository
    {
        private readonly IEnumerable<Account> accounts;

        public MockAccountRepository()
        {
            accounts = new List<Account>
            {
                new Account("A", 0m),
                new Account("B", 10m),
                new Account("C", 20m),
                new Account("D", 30m),
                new Account("E", 40m)
            };
        } 

        #region Implementation of IAccountRepository

        public IEnumerable<Account> GetAll()
        {
            return accounts;
        }

        public Account GetAccount(string accountName)
        {
            var account = accounts.SingleOrDefault(a => a.AccountName == accountName);
            if(account == null)
            {
                throw new AccountNotFoundException($"Account {accountName} not found.");
            }
            return account;
        }

        public IEnumerable<Account> Contains(string text)
        {
            return accounts.Where(a => a.AccountName.Contains(text));
        }

        #endregion
    }
}
