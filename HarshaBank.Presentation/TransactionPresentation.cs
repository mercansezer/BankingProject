using HarshaBank.BusinessLogicLayer;
using HarshaBank.BusinessLogicLayer.BLLContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
namespace HarshaBank.Presentation
{
    internal static class TransactionPresentation
    {

        public static void AddTransaction()
        {
            try
            {

                Transaction transaction = new Transaction();
                IAccountBusinessLogicLayer accountBusinessLogic = new AccountBusinessLogicLayer();
                ITransactionBusinessLogicLayer transactionBusinessLogic = new TransactionBusinessLogicLayer();


                //VIEW ACCOUNTS TO USER
                List<Account> accounts = accountBusinessLogic.GetAccounts();
                if (accounts.Count <= 0)
                {

                    Console.WriteLine("There is not any account");
                    return;
                }
                AccountPresentation.ViewAccounts();

                //LET USER TO SELECT SENDER ACCOUNT 
                Console.WriteLine("Select Account Number for Sender : ");

                long senderAccountNumber;

                while (!long.TryParse(Console.ReadLine(), out senderAccountNumber))
                {

                }

                var senderAccount = accountBusinessLogic.GetAccountsByCondition(item => item.AccountNumber == senderAccountNumber).FirstOrDefault();

                if (senderAccount == null)
                {
                    Console.WriteLine("Sender Account is not found");
                    return;
                }

                //ASK USER FOR TRANSACTION REMARK
                Console.WriteLine("Enter transaction remarks : ");

                string remarks = Console.ReadLine();

                while (string.IsNullOrEmpty(remarks))
                {
                    Console.WriteLine("Remarks cannot be empty! Please provide a description for the transaction.");
                    Console.Write("Enter transaction remarks again: ");
                    remarks = Console.ReadLine();
                }



                //LET USER TO SELECT RECEIVER ACCOUNT
                Console.WriteLine("Select Account Number for Receiver ");

                long receiverAccountNumber;

                while (!long.TryParse(Console.ReadLine(), out receiverAccountNumber))
                {
                }

                var receiverAccount = accountBusinessLogic.GetAccountsByCondition(item => item.AccountNumber == receiverAccountNumber).FirstOrDefault();

                if (receiverAccount == null)
                {
                    Console.WriteLine("Receiver account is not found");
                    return;
                }

                //GET AMOUNT FROM USER
                Console.WriteLine("Amount : ");

                decimal amount;

                while (!decimal.TryParse(Console.ReadLine(), out amount))
                {

                }

                transaction.Remarks = remarks;
                transaction.Amount = amount;
                transaction.FromAccountNumber = senderAccount.AccountID;
                transaction.ToAccountNumber = receiverAccount.AccountID;
                transactionBusinessLogic.AddTransaction(transaction);

                Console.WriteLine("Transaction completed successfully!");

                Console.WriteLine("\nAmount : " + transaction.Amount);
                Console.WriteLine("Sender Account Number : " + transaction.FromAccountNumber);
                Console.WriteLine("Receiver Account Number : " + transaction.ToAccountNumber);
                Console.WriteLine("Transaction Date Time : " + transaction.TransactionDateTime);

            }
            catch (TransactionException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void DeleteTransaction() { }
        public static void UpdateTransaction() { }
        public static void ViewTransactions()
        {
            try
            {
                IAccountBusinessLogicLayer accountBL = new AccountBusinessLogicLayer();
                ICustomerBusinessLogicLayer customerBL = new CustomerBusinessLogicLayer();
                ITransactionBusinessLogicLayer transactionBL = new TransactionBusinessLogicLayer();

                List<Transaction> transactions = transactionBL.GetAllTransactions();
                if (transactions.Count <= 0)
                {
                    Console.WriteLine("There is not any transaction to be listed");
                    return;
                }

                Console.WriteLine("\n********** TRANSACTION HISTORY **********");

                foreach (Transaction transaction in transactions)
                {
                    // 1. Sender (Gönderen) bilgilerini bulalım
                    var senderAcc = accountBL.GetAccountsByCondition(a => a.AccountID == transaction.FromAccountNumber).FirstOrDefault();
                    var senderCust = senderAcc != null ? customerBL.GetCustomersByCondition(c => c.CustomerID == senderAcc.CustomerID).FirstOrDefault() : null;

                    // 2. Receiver (Alıcı) bilgilerini bulalım
                    var receiverAcc = accountBL.GetAccountsByCondition(a => a.AccountID == transaction.ToAccountNumber).FirstOrDefault();
                    var receiverCust = receiverAcc != null ? customerBL.GetCustomersByCondition(c => c.CustomerID == receiverAcc.CustomerID).FirstOrDefault() : null;

                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine($"Transaction ID: {transaction.TransactionID}");
                    Console.WriteLine($"Date: {transaction.TransactionDateTime:dd/MM/yyyy HH:mm:ss}");

                    // Gönderen detayları
                    string senderInfo = senderCust != null ? $"{senderCust.CustomerName} ({senderAcc.AccountNumber})" : "Unknown Sender";
                    Console.WriteLine($"From: {senderInfo}");

                    // Alıcı detayları
                    string receiverInfo = receiverCust != null ? $"{receiverCust.CustomerName} ({receiverAcc.AccountNumber})" : "Unknown Receiver";
                    Console.WriteLine($"To: {receiverInfo}");

                    Console.WriteLine($"Amount: {transaction.Amount:C}"); // C formatı para birimi simgesi ekler
                    Console.WriteLine($"Description: {transaction.Remarks}");
                }
                Console.WriteLine("------------------------------------------");
            }
            catch (TransactionException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static void SearchTransaction() { }

    }
}
