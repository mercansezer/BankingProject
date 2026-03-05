using HarshaBank.BusinessLogicLayer.BLLContracts;
using HarshaBank.DataAccessLayer;
using HarshaBank.DataAccessLayer.DALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using System;
using System.Collections.Generic;
namespace HarshaBank.BusinessLogicLayer
{
    /// <summary>
    ///  Implements business logic operations for accounts, coordinating between the UI(AccountPresentationLayer) and data access layers.
    /// </summary>
    public class AccountBusinessLogicLayer : IAccountBusinessLogicLayer
    {

        /// <summary>
        /// Holds references to required data access layer objects for account operations.
        /// </summary>
        #region fields
        private IAccountsDataAccessLayer _accountsDataAccessLayer;
        #endregion


        /// <summary>
        /// Initializes the business logic layer and sets up the data access layer.
        /// </summary>
        #region constructor
        public AccountBusinessLogicLayer()
        {
            _accountsDataAccessLayer = new AccountsDataAccessLayer();
        }
        #endregion





        #region methods

        /// <summary>
        /// Retrieves all accounts through the data access layer.
        /// </summary>
        /// <returns></returns>
        public List<Account> GetAccounts()
        {

            try
            {
                return _accountsDataAccessLayer.GetAccounts();

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
        /// Retrieves accounts that satisfy the given condition through the data access layer.
        /// </summary>
        /// <param name="predicate">Condition used to filter accounts.</param>
        /// <returns>A list of Account objects matching the predicate.</returns>
        public List<Account> GetAccountsByCondition(Predicate<Account> predicate)
        {
            try
            {
                return _accountsDataAccessLayer.GetAccountsByCondition(predicate);

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
        /// Adds a new account with an automatically generated account number.
        /// </summary>
        /// <param name="account">The Account object to add.</param>
        /// <returns>The unique ID of the newly added account.</returns>
        public Guid AddAcount(Account account)
        {
            try
            {
                long maxAccountNumber = 0;

                List<Account> accounts = _accountsDataAccessLayer.GetAccounts();

                foreach (Account item in accounts)
                {
                    if (item.AccountNumber > maxAccountNumber)
                    {
                        maxAccountNumber = item.AccountNumber;
                    }
                }


                if (accounts.Count >= 1)
                {
                    account.AccountNumber = maxAccountNumber + 1;
                }
                else
                {
                    account.AccountNumber = HarshaBank.Configuration.Settings.BaseAccountCode + 1;
                }

                return _accountsDataAccessLayer.AddAcount(account);
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
        /// Deletes an account by its ID through the data access layer.
        /// </summary>
        /// <param name="accountID">The unique ID of the account to delete.</param>
        /// <returns>True if the account was successfully deleted; otherwise, false.</returns>
        public bool DeleteAccount(Guid accountID)
        {
            try
            {
                return _accountsDataAccessLayer.DeleteAccount(accountID);
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
        /// Updates an existing account through the data access layer.
        /// </summary>
        /// <param name="account">The Account object containing updated values.</param>
        /// <returns>True if the account was successfully updated; otherwise, false.</returns>
        public bool UpdateAccount(Account account)
        {
            try
            {
                return _accountsDataAccessLayer.UpdateAccount(account);
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

        #endregion
    }
}
