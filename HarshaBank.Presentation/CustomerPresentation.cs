using HarshaBank.BusinessLogicLayer.BLLContracts;
using HarshaBank.Entities;
using HarshaBank.Entities.Contracts;
using HarshaBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
namespace HarshaBank.Presentation
{
    internal static class CustomerPresentation
    {

        public static void AddCustomer()
        {

            ICustomerBusinessLogicLayer businessLogicLayer = new CustomerBusinessLogicLayer();
            ICustomer customer = new Customer();
            try
            {
                Console.WriteLine("*****ADD CUSTOMER*****");

                Console.WriteLine("Customer Name : ");
                string customerName = Console.ReadLine();
                customer.CustomerName = customerName;

                Console.WriteLine("Address : ");
                string address = Console.ReadLine();
                customer.Adress = address;

                Console.WriteLine("Landmark : ");
                string landmark = Console.ReadLine();
                customer.Landmark = landmark;

                Console.WriteLine("City : ");
                string city = Console.ReadLine();
                customer.City = city;

                Console.WriteLine("Country : ");
                string country = Console.ReadLine();
                customer.Country = country;

                Console.WriteLine("Mobile : ");
                string mobile = Console.ReadLine();
                customer.Mobile = mobile;
            }
            catch (CustomerException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Guid newCustomerId = businessLogicLayer.AddCustomer(customer as Customer);

            List<Customer> matchingCustomers = businessLogicLayer.GetCustomersByCondition(item => item.CustomerID == newCustomerId);

            if (matchingCustomers.Count > 0)
            {
                Console.WriteLine(matchingCustomers[0].CustomerCode);
            }
            else
            {
                Console.WriteLine("Customer Not added");
            }

        }


        public static void ViewCustomers()
        {
            try
            {
                ICustomerBusinessLogicLayer businessLogicLayer = new CustomerBusinessLogicLayer();
                List<Customer> customers = businessLogicLayer.GetCustomers();
                if (customers.Count == 0)
                {
                    Console.WriteLine("No customers\n");
                    return;
                }

                Console.WriteLine("*****ALL CUSTOMERS*****");
                foreach (Customer customer in customers)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Customer Name : " + customer.CustomerName);
                    Console.WriteLine("Customer Code : " + customer.CustomerCode);
                    Console.WriteLine("Customer Country : " + customer.Country);
                    Console.WriteLine("Customer City : " + customer.City);
                    Console.WriteLine("Customer Address : " + customer.Adress);
                    Console.WriteLine("Customer LandMark :  " + customer.Landmark);
                    Console.WriteLine("Customer Mobile :  " + customer.Mobile);
                }

            }
            catch (CustomerException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteCustomer()
        {
            try
            {
                ICustomerBusinessLogicLayer customerBusinessLogicLayer = new CustomerBusinessLogicLayer();

                if (customerBusinessLogicLayer.GetCustomers().Count <= 0)
                {
                    Console.WriteLine("No customers were found to list.");
                    return;
                }

                Console.WriteLine("***** DELETE CUSTOMER *****");

                ViewCustomers();

                Console.WriteLine("Enter the customer code that you want to delete : ");

                long customerCode;

                bool success = long.TryParse(Console.ReadLine(), out customerCode);

                if (success)
                {
                    var existingCustomer = customerBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerCode == customerCode).FirstOrDefault();

                    if (existingCustomer != null)
                    {
                        bool isDeleted = customerBusinessLogicLayer.DeleteCustomer(existingCustomer.CustomerID);

                        string message = isDeleted ? "Customer is deleted successfully" : "Customer can not be deleted ! ";

                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("Customer not found");
                    }
                }
                else
                {
                    Console.WriteLine("Customer code is not valid !");
                }

            }
            catch (CustomerException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void UpdateCustomer()
        {
            try
            {
                ICustomerBusinessLogicLayer customerBusinessLogicLayer = new CustomerBusinessLogicLayer();

                if (customerBusinessLogicLayer.GetCustomers().Count <= 0)
                {
                    Console.WriteLine("There are no customers to list for the update.");
                    return;
                }

                Console.WriteLine("***** UPDATE CUSTOMER *****");

                ViewCustomers();

                Console.WriteLine("Enter the customer code that you want to update : ");

                long customerCode;

                bool success = long.TryParse(Console.ReadLine(), out customerCode);

                if (success)
                {
                    var existingCustomer = customerBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerCode == customerCode).FirstOrDefault();

                    if (existingCustomer != null)
                    {
                        Console.WriteLine("New Customer Name : ");
                        existingCustomer.CustomerName = Console.ReadLine();

                        Console.WriteLine("New Customer Country : ");
                        existingCustomer.Country = Console.ReadLine();

                        Console.WriteLine("New Customer Address : ");
                        existingCustomer.Adress = Console.ReadLine();

                        Console.WriteLine("New Customer City : ");
                        existingCustomer.City = Console.ReadLine();

                        Console.WriteLine("New Customer Landmark : ");
                        existingCustomer.Landmark = Console.ReadLine();

                        Console.WriteLine("New Customer Mobile : ");
                        existingCustomer.Mobile = Console.ReadLine();

                        bool isUpdated = customerBusinessLogicLayer.UpdateCustomer(existingCustomer);

                        string message = isUpdated ? "The customer is updated successfully " : "The customer can not be updated !";

                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("Customer not found !");
                    }
                }
                else
                {
                    Console.WriteLine("Customer code is not valid ! ");
                }


            }
            catch (CustomerException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SearchCustomers()
        {
            try
            {
                ICustomerBusinessLogicLayer customerBusinessLogicLayer = new CustomerBusinessLogicLayer();

                if (customerBusinessLogicLayer.GetCustomers().Count <= 0)
                {
                    Console.WriteLine("There are no customers to search");
                    return;
                }

                ViewCustomers();

                Console.WriteLine("Enter the customer code you that you want to search : ");

                long customerCode;

                bool success = long.TryParse(Console.ReadLine(), out customerCode);

                if (success)
                {
                    var existingCustomer = customerBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerCode == customerCode).FirstOrDefault();

                    if (existingCustomer != null)
                    {
                        Console.WriteLine("Customer Name : " + existingCustomer.CustomerName);
                        Console.WriteLine("Customer Address : " + existingCustomer.Adress);
                        Console.WriteLine("Customer City : " + existingCustomer.City);
                        Console.WriteLine("Customer Country : " + existingCustomer.Country);
                        Console.WriteLine("Customer Landmark : " + existingCustomer.Landmark);
                        Console.WriteLine("Customer Mobile : " + existingCustomer.Mobile);
                    }
                    else
                    {
                        Console.WriteLine("There is not customer with that code ");
                    }
                }
                else
                {
                    Console.WriteLine("Customer code is not valid ! ");
                }

            }
            catch (CustomerException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
