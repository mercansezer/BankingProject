using HarshaBank.DataAccessLayer.DALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using System;
using System.Collections.Generic;


namespace HarshaBank.DataAccessLayer
{

    /// <summary>
    /// Provides data access operations for Account entities.
    /// </summary>
    public class AccountsDataAccessLayer : IAccountsDataAccessLayer
    {


        #region fields
        /// <summary>
        /// Stores the in-memory list of accounts.
        /// </summary>
        private static List<Account> _accounts;
        #endregion


        #region properties
        /// <summary>
        /// Provides access to the account collection.
        /// </summary>
        private static List<Account> accounts { get => _accounts; set => _accounts = value; }
        #endregion




        #region constructor
        /// <summary>
        /// Initializes the static account list when the class is first loaded.
        /// </summary>
        static AccountsDataAccessLayer()
        {
            _accounts = new List<Account>();
        }
        #endregion




        #region methods

        /// <summary>
        /// Returns a new list of accounts, each being a clone of the original.
        /// Ensures the original list remains unchanged.
        /// </summary>
        /// <returns>A list of cloned Account objects.</returns>
        public List<Account> GetAccounts()
        {
            try
            {
                List<Account> clonedAccountList = new List<Account>();

                accounts.ForEach(account => clonedAccountList.Add(account.Clone() as Account));

                return clonedAccountList;
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }



        /// <summary>
        /// Returns a list of cloned accounts that match the given condition.
        /// </summary>
        /// <param name="predicate">Condition used to filter accounts.</param>
        /// <returns>A list of cloned Account objects satisfying the predicate.</returns>
        public List<Account> GetAccountsByCondition(Predicate<Account> predicate)
        {
            try
            {
                List<Account> filteredAccountList = accounts.FindAll(predicate);

                List<Account> clonedAccountsList = new List<Account>();

                filteredAccountList.ForEach(item => clonedAccountsList.Add(item.Clone() as Account));

                return clonedAccountsList;
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// Adds a new account to the list and assigns it a unique ID.
        /// </summary>
        /// <param name="account">The Account object to add.</param>
        /// <returns>The unique ID of the newly added account.</returns>
        public Guid AddAcount(Account account)
        {
            try
            {
                account.AccountID = Guid.NewGuid();

                Guid accountId = account.AccountID;

                accounts.Add(account);

                return accountId;
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// Deletes an account with the specified ID from the list.
        /// </summary>
        /// <param name="accountID">The unique ID of the account to delete.</param>
        /// <returns>True if the account was found and deleted; otherwise, false.</returns>
        public bool DeleteAccount(Guid accountID)
        {
            try
            {
                if (accounts.RemoveAll(item => item.AccountID == accountID) > 0)
                {
                    return true;
                }
                return false;

            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                {
                    throw;
                }
            }
        }


        /// <summary>
        /// Updates the details of an existing account in the list.
        /// </summary>
        /// <param name="account">The Account object containing updated values.</param>
        /// <returns>True if the account was found and updated; otherwise, false.</returns>
        public bool UpdateAccount(Account account)
        {
            try
            {
                Account existingAccount = accounts.Find(item => item.AccountID == account.AccountID);

                if (existingAccount != null)
                {
                    existingAccount.AccountID = account.AccountID;
                    existingAccount.AccountNumber = account.AccountNumber;
                    existingAccount.CustomerID = account.CustomerID;
                    existingAccount.Balance = account.Balance;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (CustomerException)
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
