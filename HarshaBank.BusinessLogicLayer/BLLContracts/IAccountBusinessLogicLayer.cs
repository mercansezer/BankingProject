using HarshaBank.Entities;
using System;
using System.Collections.Generic;

namespace HarshaBank.BusinessLogicLayer.BLLContracts
{

    /// <summary>
    /// Defines business logic operations for managing accounts.
    /// </summary>
    public interface IAccountBusinessLogicLayer
    {

        /// <summary>
        /// Retrieves all accounts.
        /// </summary>
        /// <returns>List of all accounts.</returns>
        List<Account> GetAccounts();

        /// <summary>
        /// Retrieves accounts that match the specified condition.
        /// </summary>
        /// <param name="predicate">Condition used to filter accounts.</param>
        /// <returns>List of matching accounts.</returns>
        List<Account> GetAccountsByCondition(Predicate<Account> predicate);

        /// <summary>
        /// Adds a new account.
        /// </summary>
        /// <param name="account">Account to be added.</param>
        /// <returns>ID of the newly created account.</returns>
        Guid AddAcount(Account account);

        /// <summary>
        /// Deletes an account by its ID.
        /// </summary>
        /// <param name="accountID">ID of the account to delete.</param>
        /// <returns>True if deletion is successful.</returns>
        bool DeleteAccount(Guid accountID);


        /// <summary>
        /// Updates an existing account.
        /// </summary>
        /// <param name="account">Account with updated values.</param>
        /// <returns>True if update is successful.</returns>
        bool UpdateAccount(Account account);
    }
}
