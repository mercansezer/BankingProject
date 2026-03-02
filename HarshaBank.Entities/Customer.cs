using HarshaBank.Entities.Contracts;
using System;

namespace HarshaBank.Entities
{
    public class Customer : ICustomer
    {
        private Guid _customerID;
        private long _customerCode;
        private string _customerName;
        private string _adress;
        private string _landmark;
        private string _city;
        private string _country;
        private string _mobile;

        public Guid CustomerID { get => _customerID; set => _customerID = value; }
        public long CustomerCode { get => _customerCode; set => _customerCode = value; }
        public string CustomerName { get => _customerName; set => _customerName = value; }
        public string Adress { get => _adress; set => _adress = value; }
        public string Landmark { get => _landmark; set => _landmark = value; }
        public string City { get => _city; set => _city = value; }
        public string Country { get => _country; set => _country = value; }
        public string Mobile { get => _mobile; set => _mobile = value; }

    }
}
