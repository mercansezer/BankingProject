using HarshaBank.DataAccessLayer.DALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using System;
using System.Collections.Generic;

namespace HarshaBank.DataAccessLayer
{

    /// <summary>
    /// Provides data access operations for managing transaction records.
    /// </summary>
    public class TransactionDataAccessLayer : ITransactionDataAccessLayer
    {


        #region fields
        /// <summary>
        /// Stores all transaction records in memory.
        /// </summary>
        private static List<Transaction> _transactions;
        #endregion


        #region constructors
        /// <summary>
        /// Initializes the transaction storage when the class is first loaded.
        /// </summary>
        static TransactionDataAccessLayer()
        {
            _transactions = new List<Transaction>();
        }
        #endregion

        #region properties
        /// <summary>
        /// Provides access to the in-memory transaction list.
        /// </summary>
        private List<Transaction> Transactions { get => _transactions; set => _transactions = value; }
        #endregion



        #region methods
        /// <summary>
        /// Retrieves all transactions as cloned objects to preserve the original list.
        /// </summary>
        /// <returns>A list of cloned Transaction objects.</returns>
        public List<Transaction> GetAllTransactions()
        {
            try
            {
                List<Transaction> clonedTransactions = new List<Transaction>();

                Transactions.ForEach(item => clonedTransactions.Add(item.Clone() as Transaction));

                return clonedTransactions;
            }
            catch (TransactionException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Retrieves transactions that match the specified condition as cloned objects.
        /// </summary>
        /// <param name="predicate">Condition used to filter transactions.</param>
        /// <returns>A list of cloned Transaction objects satisfying the predicate.</returns>
        public List<Transaction> GetTransactionsByCondition(Predicate<Transaction> predicate)
        {
            try
            {
                List<Transaction> filteredTransactions = Transactions.FindAll(predicate);

                List<Transaction> clonedTransactions = new List<Transaction>();

                filteredTransactions.ForEach(item => clonedTransactions.Add(item.Clone() as Transaction));

                return clonedTransactions;
            }
            catch (TransactionException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds a new transaction to the in-memory list and assigns it a unique ID.
        /// </summary>
        /// <param name="transaction">The Transaction object to add.</param>
        /// <returns>The unique ID of the newly added transaction.</returns>
        public Guid AddTransaction(Transaction transaction)
        {
            try
            {
                transaction.TransactionID = Guid.NewGuid();
                transaction.TransactionDateTime = DateTime.Now;

                Transactions.Add(transaction);

                return transaction.TransactionID;
            }
            catch (TransactionException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Deletes a transaction by its unique ID from the in-memory list.
        /// </summary>
        /// <param name="transactionId">The unique ID of the transaction to delete.</param>
        /// <returns>True if the transaction was found and deleted; otherwise, false.</returns>
        public bool DeleteTransaction(Guid transactionId)
        {
            try
            {
                if (Transactions.RemoveAll(item => item.TransactionID == transactionId) > 0)
                {
                    return true;
                }

                return false;
            }
            catch (TransactionException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Updates an existing transaction in the in-memory list.
        /// </summary>
        /// <param name="transaction">The Transaction object containing updated values.</param>
        /// <returns>True if the transaction was found and updated; otherwise, false.</returns>
        public bool UpdateTransaction(Transaction transaction)
        {
            try
            {
                Transaction existingTransaction = Transactions.Find(t => t.TransactionID == transaction.TransactionID);

                if (existingTransaction != null)
                {
                    existingTransaction.TransactionID = transaction.TransactionID;
                    existingTransaction.Remarks = transaction.Remarks;
                    existingTransaction.TransactionDateTime = transaction.TransactionDateTime;
                    existingTransaction.ToAccountNumber = transaction.ToAccountNumber;
                    existingTransaction.FromAccountNumber = transaction.FromAccountNumber;
                    existingTransaction.Amount = transaction.Amount;
                    return true;
                }

                return false;
            }
            catch (TransactionException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
