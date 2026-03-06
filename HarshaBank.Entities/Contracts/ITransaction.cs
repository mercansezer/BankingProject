using System;

namespace HarshaBank.Entities.Contracts
{
    /// <summary>
    /// Represents a bank transaction between two accounts.
    /// </summary>
    public interface ITransaction
    {
        /// <summary>
        /// Unique identifier of the transaction.
        /// </summary>
        Guid TransactionID { get; set; }

        /// <summary>
        /// Account number from which the money is sent.
        /// </summary>
        Guid FromAccountNumber { get; set; }

        /// <summary>
        /// Account number that receives the money.
        /// </summary>
        Guid ToAccountNumber { get; set; }

        /// <summary>
        /// Amount of money transferred in the transaction.
        /// </summary>
        decimal Amount { get; set; }

        /// <summary>
        /// Date and time when the transaction occurred.
        /// </summary>
        DateTime TransactionDateTime { get; set; }
        /// <summary>
        /// Additional notes or description about the transaction.
        /// </summary>
        string Remarks { get; set; }

    }
}
