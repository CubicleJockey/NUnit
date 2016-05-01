using NUnitObjects.Exceptions;

namespace NUnitObjects.Models
{
    public class Account
    {
        #region Properties
        public string AccountName { get; }
        public decimal Balance { get; private set; }

        #endregion Properties

        #region Constructors

        public Account(string accountName)
        {
            AccountName = accountName;
            Balance = 0;
        }

        public Account(string accountName, decimal startingBalance)
        {
            AccountName = accountName;
            Balance = startingBalance;
        }

        #endregion Constructors

        #region Methods

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void WithDraw(decimal amount)
        {
            if(amount > Balance)
            {
                throw new InsufficientFundsException();
            }
            Balance -= amount;
        }

        public void TransferFunds(Account destination, decimal amount)
        {
            if(amount > Balance)
            {
                throw new InsufficientFundsException();
            }
            destination.Deposit(amount);
            WithDraw(amount);
        }

        #endregion Methods

    }
}
