using HarshaBank.Entities.Contracts;
using HarshaBank.Exceptions;

using System;

namespace HarshaBank.Entities
{
    /// <summary>
    /// Represents customer of the bank
    /// </summary>
    public class Customer : ICustomer
    {


        #region private fields
        private Guid _customerID;
        private long _customerCode;
        private string _customerName;
        private string _adress;
        private string _landmark;
        private string _city;
        private string _country;
        private string _mobile;
        #endregion



        #region public properties
        /// <summary>
        /// Guid of Customer for Unique identification
        /// </summary>
        public Guid CustomerID { get => _customerID; set => _customerID = value; }

        /// <summary>
        /// Auto-generated code number of customer
        /// </summary>
        public long CustomerCode
        {
            get => _customerCode;
            set
            {
                if (value > 0)
                {
                    _customerCode = value;
                }
                else
                {
                    throw new CustomerException("Customer code should be positive only");
                }
            }
        }

        /// <summary>
        /// Name of the customer
        /// </summary>
        public string CustomerName
        {
            get => _customerName;
            set
            {
                if (value.Length <= 40 && string.IsNullOrWhiteSpace(value) == false)
                {
                    _customerName = value;
                }
                else
                {
                    throw new CustomerException("Customer name should not be null and less than 40 characters long.");
                }

            }
        }

        /// <summary>
        /// Address of the customer
        /// </summary>
        public string Adress { get => _adress; set => _adress = value; }
        /// <summary>
        /// Landmark of the customer's address
        /// </summary>
        public string Landmark { get => _landmark; set => _landmark = value; }
        /// <summary>
        /// City of the customer
        /// </summary>
        public string City { get => _city; set => _city = value; }

        /// <summary>
        /// Country of the customer
        /// </summary>
        public string Country { get => _country; set => _country = value; }

        /// <summary>
        /// 10-digit Mobile of the customer
        /// </summary>
        public string Mobile
        {
            get => _mobile;
            set
            {
            }
        }
        #endregion

    }
}
