using System;

namespace HarshaBank.Entities.Contracts
{

    /// <summary>
    ///  Represents a bank account entity with basic account details.
    /// </summary>
    public interface IAccount
    {

        #region properties
        /// <summary>
        /// Unique identifier of the account.
        /// </summary>
        Guid AccountID { get; set; }

        /// <summary>
        /// Bank account number assigned to the account.
        /// </summary>
        long AccountNumber { get; set; }

        /// <summary>
        /// Current balance available in the account.
        /// </summary>
        decimal Balance { get; set; }

        /// <summary>
        /// Identifier of the customer who owns the account.
        /// </summary>
        Guid CustomerID { get; set; }

        #endregion
    }
}
