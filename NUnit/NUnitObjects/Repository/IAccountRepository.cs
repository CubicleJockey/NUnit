using System.Collections.Generic;
using NUnitObjects.Models;

namespace NUnitObjects.Repository
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
        Account GetAccount(string accountName);
        IEnumerable<Account> Contains(string text);
    }
}