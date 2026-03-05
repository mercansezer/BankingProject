using HarshaBank.BusinessLogicLayer;
using HarshaBank.BusinessLogicLayer.BLLContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HarshaBank.Presentation
{
    public static class AccountPresentation
    {

        public static void AddAccount()
        {

            try
            {
                Account account = new Account();

                IAccountBusinessLogicLayer accountBusinessLogicLayer = new AccountBusinessLogicLayer();
                ICustomerBusinessLogicLayer customerBusinessLogicLayer = new CustomerBusinessLogicLayer();

                if (customerBusinessLogicLayer.GetCustomers().Count <= 0)
                {
                    Console.WriteLine("There is not any customers to make an account");
                    return;
                }



                Console.WriteLine();
                Console.WriteLine("***** ADD ACCOUNT *****");

                //LIST ALL CUSTOMERS
                CustomerPresentation.ViewCustomers();

                //SELECT CUSTOMER THAT YOU WANT TO GET CUSTOMERID TO MATCH WITH ACCOUNTID IN ACCOUNT ENTITY
                Console.WriteLine("\nSelect Customer Code : ");
                long customerCode;

                bool isValidCode = long.TryParse(Console.ReadLine(), out customerCode);


                if (isValidCode)
                {
                    var customer = customerBusinessLogicLayer.GetCustomersByCondition(cust => cust.CustomerCode == customerCode).FirstOrDefault();
                    if (customer == null)
                    {
                        Console.WriteLine("Customer not found ! ");
                        return;
                    }
                    else
                    {
                        account.CustomerID = customer.CustomerID;

                    }


                }
                else
                {
                    Console.WriteLine("The customer code is not valid ! ");
                    return;
                }

                //ADD ACCOUNT INTO THE LIST USING ACCOUNTBUSINESSLOGIC

                accountBusinessLogicLayer.AddAcount(account);


            }
            catch (AccountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void DeleteAccount()
        {
            try
            {
                IAccountBusinessLogicLayer accountBusinessLogicLayer = new AccountBusinessLogicLayer();

                //LIST ALL THE ACCOUNTS
                if (accountBusinessLogicLayer.GetAccounts().Count <= 0)
                {
                    Console.WriteLine("There is not any account to be deleted");
                    return;
                }

                ViewAccounts();

                //GET THE ACCOUNT NUMBER AS INPUT FROM THE USER

                long accountNumber;
                Console.WriteLine("Enter account number which you want to delete :");
                bool isValid = long.TryParse(Console.ReadLine(), out accountNumber);

                if (isValid)
                {
                    //GET ACCOUNT USIN ACCOUNTBLL
                    Account account = accountBusinessLogicLayer.GetAccountsByCondition(item => item.AccountNumber == accountNumber).FirstOrDefault();

                    if (account != null)
                    {
                        //CHECK IF THE BALANCE IS 0 or NOT. THE BALANCE SHOULD BE 0. HE SHOULDN'T HAVE MONEY IN ACCOUNT.
                        if (account.Balance != 0)
                        {
                            Console.WriteLine($"\nError: Account has a balance of {account.Balance}. Please withdraw money before deleting!");
                            return;
                        }

                        //ASK USER AGAIN IF HE IS SURE THAT HE WANTS TO DELTE HIS ACCOUNT
                        Console.Write($"Are you sure you want to delete account {accountNumber}? (y/n): ");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            bool isDeleted = accountBusinessLogicLayer.DeleteAccount(account.AccountID);
                            string message = isDeleted ? "Account is deleted successfully" : "Account can not be deleted";

                            Console.WriteLine(message);

                            ViewAccounts();
                        }
                        else
                        {
                            Console.WriteLine("Deletion cancelled.");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Invalid number !");
                }

            }
            catch (AccountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void UpdateAccount()
        {
            try
            {
                IAccountBusinessLogicLayer accountBusinessLogicLayer = new AccountBusinessLogicLayer();
                ICustomerBusinessLogicLayer customerBusinessLogicLayer = new CustomerBusinessLogicLayer();

                //IF THERE IS NOT ANY ACCOUNT THEN SHOW THE MESSAGE
                if (accountBusinessLogicLayer.GetAccounts().Count <= 0)
                {
                    Console.WriteLine("There is not any account to be updated");
                    return;
                }

                //SHOW ALL THE ACCOUNTS TO USER
                Console.WriteLine("\n***** ALL ACCOUNTS *****");
                ViewAccounts();


                //GET ACCOUNT NUMBER FROM USER AND FIND ACCOUNT INSIDE THE DATABASE BASED ON THE GIVEN ACCOUNT NUMBER
                Console.WriteLine("Enter Account Number  : ");

                long accountNumber;

                while (!long.TryParse(Console.ReadLine(), out accountNumber))
                {
                }

                Account existingAccount = accountBusinessLogicLayer.GetAccountsByCondition(item => item.AccountNumber == accountNumber).FirstOrDefault();

                if (existingAccount == null)
                {
                    Console.WriteLine("Invalid Account Number.\n");
                    return;
                }

                //SHOW THE CUSTOMERS TO USERS
                Console.WriteLine("***** CUSTOMERS *****");
                CustomerPresentation.ViewCustomers();

                //GET THE CUSTOMERCODE WHICH USER WANT TO UPDATE
                long customerCode;

                Console.WriteLine("Enter customer code : ");

                while (!long.TryParse(Console.ReadLine(), out customerCode))
                {

                }

                Customer existingCustomer = customerBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerCode == customerCode).FirstOrDefault();

                if (existingCustomer == null)
                {
                    Console.WriteLine("Invalid Customer Code.\n");
                    return;
                }

                existingAccount.CustomerID = existingCustomer.CustomerID;

                Console.WriteLine("Balance : ");

                decimal newBalance;
                while (!decimal.TryParse(Console.ReadLine(), out newBalance))
                {

                }

                existingAccount.Balance = newBalance;

                bool isUpdated = accountBusinessLogicLayer.UpdateAccount(existingAccount);

                string message = isUpdated ? "Account is updated" : "Account can not be updated";

                Console.WriteLine(message);

                ViewAccounts();

            }
            catch (AccountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void SearchAccounts()
        {
            try
            {
                IAccountBusinessLogicLayer accountBusinessLogicLayer = new AccountBusinessLogicLayer();
                ICustomerBusinessLogicLayer customerBusinessLogicLayer = new CustomerBusinessLogicLayer();

                //SHOW ALL THE ACCOUNTS IF THERE IS ANY
                List<Account> accounts = accountBusinessLogicLayer.GetAccounts();
                if (accounts.Count <= 0)
                {
                    Console.WriteLine("There is not any account to be shown");
                    return;
                }
                Console.WriteLine("***** ALL ACCOUNTS *****");
                ViewAccounts();

                //GET ACCOUNT NUMBER FROM USER
                long accountNumber;
                Console.WriteLine("Enter account number : ");

                while (!long.TryParse(Console.ReadLine(), out accountNumber))
                {
                }

                //GET ACCOUNT BASED ON THE GIVEN ACCOUNT NUMBER BY USER
                Account existingAccount = accountBusinessLogicLayer.GetAccountsByCondition(item => item.AccountNumber == accountNumber).FirstOrDefault();

                if (existingAccount == null)
                {
                    Console.WriteLine("\nInvalid account number !");
                    return;
                }

                Console.WriteLine(existingAccount.AccountNumber);
                Console.WriteLine(existingAccount.Balance);

                //FIND RELEVANT CUSTOMER BASED ON THE ACCOUNTID.

                Customer existingCustomer = customerBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerID == existingAccount.CustomerID).FirstOrDefault();

                if (existingCustomer == null)
                {
                    Console.WriteLine("\n Customer not found !");
                    return;
                }

                Console.WriteLine(existingCustomer.CustomerName);
                Console.WriteLine(existingCustomer.Country);

            }
            catch (AccountException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void ViewAccounts()
        {
            try
            {
                IAccountBusinessLogicLayer accountBusinessLogicLayer = new AccountBusinessLogicLayer();
                ICustomerBusinessLogicLayer customerBusinessLogicLayer = new CustomerBusinessLogicLayer();

                List<Account> accounts = accountBusinessLogicLayer.GetAccounts();
                //Check if there is any account or not, if there is not than show a message and return.
                if (accounts.Count == 0)
                {
                    Console.WriteLine("There is no any account to be shown !");
                    return;
                }

                List<Customer> allCustomers = customerBusinessLogicLayer.GetCustomers();

                //LIST ALL THE ACCOUNTS BASED ON CUSTOMER DETAILS
                foreach (Account account in accounts)
                {
                    Console.WriteLine("Account Number : " + account.AccountNumber);
                    Console.WriteLine("Account Balance : " + account.Balance);

                    Customer customer = allCustomers.FirstOrDefault(c => c.CustomerID == account.CustomerID);

                    if (customer != null)
                    {
                        Console.WriteLine("Customer Name : " + customer.CustomerName);
                        Console.WriteLine("Customer Code : " + customer.CustomerCode);

                    }

                }

            }
            catch (AccountException ex)
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
