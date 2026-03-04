using HarshaBank.DataAccessLayer.DALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using System;
using System.Collections.Generic;
namespace HarshaBank.DataAccessLayer
{

    /// <summary>
    /// Class that handles database operations for customer data.
    /// </summary>
    public class CustomerDataAccessLayer : ICusomerDataAccessLayer
    {


        /// <summary>
        ///  A list that stores customer objects.
        /// </summary>
        private List<Customer> _customerList;

        private List<Customer> Customers { get => _customerList; set => _customerList = value; }

        /// <summary>
        /// Initializes a new instance of the CustomerDataAccessLayer class and 
        /// creates a new list to store customer data.
        /// </summary>
        public CustomerDataAccessLayer()
        {
            _customerList = new List<Customer>();
        }

        /// <summary>
        /// Adds customer to the List.
        /// </summary>
        /// <param name="customer">It is the customer that we want to add to our List.</param>
        /// <returns>It returns customer's id which we added to our List.</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                customer.CustomerID = Guid.NewGuid();

                _customerList.Add(customer);

                return customer.CustomerID;
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
        /// Deletes customer from list.
        /// </summary>
        /// <param name="customerId">The customerId which we want to delete from our list.</param>
        /// <returns>It returns true or false and it identifies if the customer is deleted or not.</returns>
        public bool DeleteCustomer(Guid customerId)
        {
            try
            {


                if (Customers.RemoveAll(item => item.CustomerID == customerId) > 0)
                {
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


        /// <summary>
        /// Retrieves a list of customers by cloning each customer from the original collection.
        /// </summary>
        /// <returns>A list of cloned customer objects.</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                List<Customer> customerList = new List<Customer>();

                Customers.ForEach(item => customerList.Add(item.Clone() as Customer));

                return customerList;
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
        /// Filters customers based on the provided condition (predicate) and returns a list of cloned customer objects.
        /// </summary>
        /// <param name="predicate">The condition used to filter customers.</param>
        /// <returns>A list of cloned customer objects that match the condition.</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                List<Customer> filteredCustomer = Customers.FindAll(predicate);

                List<Customer> customerList = new List<Customer>();

                filteredCustomer.ForEach(item => customerList.Add(item.Clone() as Customer));

                return customerList;
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
        /// It updates the customer.
        /// </summary>
        /// <param name="customer">The customer which we want to update</param>
        /// <returns>It returns true or false and it identifies if customer is updated or not.</returns>

        public bool UpdateCustomer(Customer customer)
        {

            try
            {


                Customer existingCustomer = Customers.Find(item => item.CustomerID == customer.CustomerID);

                if (existingCustomer != null)
                {
                    existingCustomer.CustomerCode = customer.CustomerCode;
                    existingCustomer.CustomerName = customer.CustomerName;
                    existingCustomer.Adress = customer.Adress;
                    existingCustomer.City = customer.City;
                    existingCustomer.Country = customer.Country;
                    existingCustomer.Landmark = customer.Landmark;
                    existingCustomer.Mobile = customer.Mobile;

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
    }
}
