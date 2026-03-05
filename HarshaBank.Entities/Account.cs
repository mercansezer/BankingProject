using HarshaBank.Entities.Contracts;
using HarshaBank.Exceptions;
using System;

namespace HarshaBank.Entities
{

    /// <summary>
    /// Represents a bank account entity and implements the IAccount contract.
    /// </summary>
    public class Account : IAccount, ICloneable
    {
        #region fields
        private Guid _accountID;
        private long _accountNumber;
        private decimal _balance;
        private Guid _customerID;
        #endregion


        #region properties
        /// <summary>
        /// Unique identifier of the account.
        /// </summary>
        public Guid AccountID { get => _accountID; set => _accountID = value; }
        /// <summary>
        /// Bank account number assigned to the account.
        /// </summary>
        public long AccountNumber
        {
            get => _accountNumber;
            set
            {
                if (value < 0)
                {

                    throw new AccountException("Account number should not be negative");
                }
                else
                {
                    _accountNumber = value;
                }
            }
        }
        /// <summary>
        /// Current balance available in the account.
        /// </summary>
        public decimal Balance
        {
            get => _balance;
            set
            {
                if (value < 0)
                {
                    throw new AccountException("Balance should not be negative");
                }
                else
                {
                    _balance = value;
                }
            }
        }
        /// <summary>
        /// Identifier of the customer who owns the account.
        /// </summary>
        public Guid CustomerID { get => _customerID; set => _customerID = value; }
        #endregion


        #region constructor
        /// <summary>
        /// Initializes a new instance of the Account class with default values.
        /// </summary>
        public Account()
        {
            AccountID = Guid.Empty;
            CustomerID = Guid.Empty;
            AccountNumber = 0L;
            Balance = 0.0m;


        }
        /// <summary>
        /// Initializes a new instance of the Account class with specified account details.
        /// </summary>
        /// <param name="accountID">Unique identifier of the account.</param>
        /// <param name="accountNumber">Bank account number.</param>
        /// <param name="balance">Initial balance of the account.</param>
        /// <param name="customerID">Identifier of the account owner.</param>
        public Account(Guid accountID, long accountNumber, decimal balance, Guid customerID)
        {
            AccountID = accountID;
            AccountNumber = accountNumber;
            Balance = balance;
            CustomerID = customerID;

        }


        #endregion


        #region methods

        /// <summary>
        /// Creates and returns a copy of the current Account object.
        /// </summary>
        /// <returns>A new Account instance with the same property values.</returns>
        public object Clone()
        {
            return new Account() { AccountID = this.AccountID, AccountNumber = this.AccountNumber, Balance = this.Balance, CustomerID = this.CustomerID };
        }
        #endregion
    }
}
