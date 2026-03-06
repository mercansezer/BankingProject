using HarshaBank.BusinessLogicLayer.BLLContracts;
using HarshaBank.DataAccessLayer;
using HarshaBank.DataAccessLayer.DALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HarshaBank.BusinessLogicLayer
{
    /// <summary>
    /// Defines business logic operations for managing transactions.
    /// </summary>
    public class TransactionBusinessLogicLayer : ITransactionBusinessLogicLayer
    {
        #region fields
        /// <summary>
        /// Holds a reference to the transaction data access layer for performing data operations.
        /// </summary>
        private ITransactionDataAccessLayer _transactionDataAccessLayer;
        private IAccountsDataAccessLayer _accountsDataAccessLayer;
        #endregion

        #region constructors
        /// <summary>
        /// Initializes the transaction business logic layer and sets up the data access layer.
        /// </summary>
        public TransactionBusinessLogicLayer()
        {
            _transactionDataAccessLayer = new TransactionDataAccessLayer();
            _accountsDataAccessLayer = new AccountsDataAccessLayer();
        }
        #endregion

        #region properties
        /// <summary>
        /// Provides access to the transaction data access layer.
        /// </summary>
        private ITransactionDataAccessLayer TransactionDataAccessLayer { get => _transactionDataAccessLayer; set => _transactionDataAccessLayer = value; }
        private IAccountsDataAccessLayer AccountsDataAccessLayer { get => _accountsDataAccessLayer; set => _accountsDataAccessLayer = value; }

        #endregion


        #region methods
        /// <summary>
        /// Retrieves all transactions through the data access layer.
        /// </summary>
        /// <returns>A list of all Transaction objects.</returns>
        public List<Transaction> GetAllTransactions()
        {
            try
            {
                return TransactionDataAccessLayer.GetAllTransactions();
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
        /// Retrieves transactions that match the specified condition through the data access layer.
        /// </summary>
        /// <param name="predicate">Condition used to filter transactions.</param>
        /// <returns>A list of Transaction objects satisfying the predicate.</returns>
        public List<Transaction> GetTransactionsByCondition(Predicate<Transaction> predicate)
        {
            try
            {
                return TransactionDataAccessLayer.GetTransactionsByCondition(predicate);
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
        /// Adds a new transaction using the data access layer.
        /// </summary>
        /// <param name="transaction">The Transaction object to add.</param>
        /// <returns>The unique ID of the newly added transaction.</returns>
        public Guid AddTransaction(Transaction transaction)
        {
            try
            {

                Account FromAccount = AccountsDataAccessLayer.GetAccountsByCondition(account => account.AccountID == transaction.FromAccountNumber).FirstOrDefault();
                Account ToAccount = AccountsDataAccessLayer.GetAccountsByCondition(account => account.AccountID == transaction.ToAccountNumber).FirstOrDefault();

                if (FromAccount != null && ToAccount != null)
                {

                    if (FromAccount.Balance < transaction.Amount)
                    {
                        throw new TransactionException($"Source account has insuffient funds for transaction of {transaction.Amount}");
                    }

                    transaction.FromAccountNumber = FromAccount.AccountID;
                    transaction.ToAccountNumber = ToAccount.AccountID;
                    FromAccount.Balance -= transaction.Amount;
                    ToAccount.Balance += transaction.Amount;
                    AccountsDataAccessLayer.UpdateAccount(FromAccount);
                    AccountsDataAccessLayer.UpdateAccount(ToAccount);
                    return TransactionDataAccessLayer.AddTransaction(transaction);

                }
                else
                {
                    throw new TransactionException("Source account or destination account number is invalid");
                }

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
        /// Deletes a transaction by its unique ID through the data access layer.
        /// </summary>
        /// <param name="transactionId">The unique ID of the transaction to delete.</param>
        /// <returns>True if the transaction was successfully deleted; otherwise, false.</returns>
        public bool DeleteTransaction(Guid transactionId)
        {
            try
            {
                return TransactionDataAccessLayer.DeleteTransaction(transactionId);
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
        /// Updates an existing transaction through the data access layer.
        /// </summary>
        /// <param name="transaction">The Transaction object containing updated values.</param>
        /// <returns>True if the transaction was successfully updated; otherwise, false.</returns>
        public bool UpdateTransaction(Transaction transaction)
        {
            try
            {
                return TransactionDataAccessLayer.UpdateTransaction(transaction);
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
