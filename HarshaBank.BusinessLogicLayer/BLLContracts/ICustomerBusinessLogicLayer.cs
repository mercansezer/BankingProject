using HarshaBank.Entities;
using System;
using System.Collections.Generic;

namespace HarshaBank.BusinessLogicLayer.BLLContracts
{
    /// <summary>
    /// Handles customer business operations.
    /// </summary>
    public interface ICustomerBusinessLogicLayer
    {

        /// <summary>
        /// Retrieves a list of all customers.
        /// </summary>
        /// <returns>A list of <see cref="Customer"/> objects representing all customers.  The list will be empty if no customers
        /// are available.</returns>
        List<Customer> GetCustomers();


        /// <summary>
        ///  Returns a list of customers which matches with the specified conditions.
        /// </summary>
        /// <param name="predicate">A function</param>
        /// <returns>Returns list of customers which matches with the conditions</returns>
        List<Customer> GetCustomersByCondition(Predicate<Customer> predicate);


        /// <summary>
        /// Adds customer to the existing customer List
        /// </summary>
        /// <param name="customer">Customer which we want to add to our list</param>
        /// <returns>Returns Guid of the added customer</returns>
        Guid AddCustomer(Customer customer);


        /// <summary>
        /// Deletes customer from the list.
        /// </summary>
        /// <param name="customerId">the customer's id which we want to delete from our list.</param>
        /// <returns>It returns true or false, it identifies whether the customer is deleted or not</returns>
        bool DeleteCustomer(Guid customerId);


        /// <summary>
        /// Updates the coming customer in our customer list.
        /// </summary>
        /// <param name="customer">Customer which we want to udapte</param>
        /// <returns>It returns true or false, it identifies whether the customer is updated or not</returns>
        bool UpdateCustomer(Customer customer);
    }
}
