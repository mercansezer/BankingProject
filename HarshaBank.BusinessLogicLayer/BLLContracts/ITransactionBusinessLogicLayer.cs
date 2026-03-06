using HarshaBank.Entities;
using System;
using System.Collections.Generic;

namespace HarshaBank.BusinessLogicLayer.BLLContracts
{
    /// <summary>
    /// Defines business logic operations for managing transactions.
    /// </summary>
    public interface ITransactionBusinessLogicLayer
    {

        /// <summary>
        /// Retrieves all transactions.
        /// </summary>
        /// <returns>A list of all Transaction objects.</returns>
        List<Transaction> GetAllTransactions();

        /// <summary>
        /// Retrieves transactions that match the specified condition.
        /// </summary>
        /// <param name="predicate">Condition used to filter transactions.</param>
        /// <returns>A list of Transaction objects satisfying the condition.</returns>
        List<Transaction> GetTransactionsByCondition(Predicate<Transaction> predicate);

        /// <summary>
        /// Adds a new transaction.
        /// </summary>
        /// <param name="transaction">The Transaction object to add.</param>
        /// <returns>The unique ID of the created transaction.</returns>
        Guid AddTransaction(Transaction transaction);

        /// <summary>
        /// Deletes a transaction by its ID.
        /// </summary>
        /// <param name="transactionId">The unique ID of the transaction.</param>
        /// <returns>True if the transaction was deleted; otherwise false.</returns>
        bool DeleteTransaction(Guid transactionId);

        /// <summary>
        /// Updates an existing transaction.
        /// </summary>
        /// <param name="transaction">The Transaction object containing updated values.</param>
        /// <returns>True if the transaction was updated; otherwise false.</returns>
        bool UpdateTransaction(Transaction transaction);
    }
}
