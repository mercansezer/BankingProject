using HarshaBank.BusinessLogicLayer.BLLContracts;
using HarshaBank.DataAccessLayer;
using HarshaBank.DataAccessLayer.DALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using System;
using System.Collections.Generic;

/// <summary>
/// Implements business logic for customer operations.
/// </summary>
public class CustomerBusinessLogicLayer : ICustomerBusinessLogicLayer
{

    #region fields
    /// <summary>
    /// Data access layer for customer operations.
    /// </summary>
    private ICusomerDataAccessLayer _customerDataAccessLayer;
    #endregion

    /// <summary>
    /// Initializes a new instance of the CustomerBusinessLogicLayer class.
    /// </summary>
    public CustomerBusinessLogicLayer()
    {

        _customerDataAccessLayer = new CustomerDataAccessLayer();
    }


    #region Methods
    /// <summary>
    /// Retrieves a list of all customers.
    /// </summary>
    /// <returns>A list of <see cref="Customer"/> objects representing all customers.  The list will be empty if no customers
    /// are available.</returns>
    public List<Customer> GetCustomers()
    {
        try
        {
            return _customerDataAccessLayer.GetCustomers();
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


    /// <summary>
    ///  Returns a list of customers which matches with the specified conditions.
    /// </summary>
    /// <param name="predicate">A function</param>
    /// <returns>Returns list of customers which matches with the conditions</returns>
    public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
    {
        try
        {
            return _customerDataAccessLayer.GetCustomersByCondition(predicate);
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


    /// <summary>
    /// Adds customer to the existing customer List
    /// </summary>
    /// <param name="customer">Customer which we want to add to our list</param>
    /// <returns>Returns Guid of the added customer</returns>
    public Guid AddCustomer(Customer customer)
    {
        try
        {
            long maxCodeNumber = 0;

            List<Customer> allCustomers = _customerDataAccessLayer.GetCustomers();

            //We are trying to find maximum code number in our customer List. If the largest number is 2001, for example, we want to make next customer's number 2002. 
            foreach (var item in allCustomers)
            {
                if (item.CustomerCode > maxCodeNumber)
                {
                    maxCodeNumber = item.CustomerCode;
                }
            }

            //If there is not any customers, I mean if it is our first customer then else block will be executed and we will use our BaseCustomerCode in Settings static class.
            if (allCustomers.Count > 0)
            {
                customer.CustomerCode = maxCodeNumber + 1;
            }
            else
            {
                customer.CustomerCode = HarshaBank.Configuration.Settings.BaseCustomerCode + 1;
            }

            return _customerDataAccessLayer.AddCustomer(customer);
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


    /// <summary>
    /// Deletes customer from the list.
    /// </summary>
    /// <param name="customerId">the customer's id which we want to delete from our list.</param>
    /// <returns>It returns true or false, it identifies whether the customer is deleted or not</returns>
    public bool DeleteCustomer(Guid customerId)
    {
        try
        {

            return _customerDataAccessLayer.DeleteCustomer(customerId);

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


    /// <summary>
    /// Updates the coming customer in our customer list.
    /// </summary>
    /// <param name="customer">Customer which we want to udapte</param>
    /// <returns>It returns true or false, it identifies whether the customer is updated or not</returns>
    public bool UpdateCustomer(Customer customer)
    {

        try
        {
            return _customerDataAccessLayer.UpdateCustomer(customer);
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
