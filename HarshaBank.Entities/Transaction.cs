using HarshaBank.Entities.Contracts;
using HarshaBank.Exceptions;
using System;

namespace HarshaBank.Entities
{

    /// <summary>
    /// Represents a bank transaction entity.
    /// </summary>
    public class Transaction : ITransaction, ICloneable
    {

        #region fields
        private Guid _transactionID;
        private Guid _fromAccountNumber;
        private Guid _toAccountNumber;
        private decimal _amount;
        private DateTime _transactionDateTime;
        private string _remarks;
        #endregion

        #region properties
        public Guid TransactionID
        {
            get => _transactionID;
            set => _transactionID = value;
        }

        public Guid FromAccountNumber
        {
            get => _fromAccountNumber;
            set
            {
                if (value == _toAccountNumber && value != Guid.Empty)
                    throw new TransactionException("FromAccountNumber and ToAccountNumber cannot be the same.");
                _fromAccountNumber = value;
            }
        }

        public Guid ToAccountNumber
        {
            get => _toAccountNumber;
            set
            {
                if (value == _fromAccountNumber && value != Guid.Empty)
                    throw new TransactionException("ToAccountNumber and FromAccountNumber cannot be the same.");
                _toAccountNumber = value;
            }
        }

        public decimal Amount
        {
            get => _amount;
            set
            {
                // Para transferi 0 veya negatif olamaz
                if (value <= 0)
                    throw new TransactionException("Amount must be greater than zero.");
                _amount = value;
            }
        }

        public DateTime TransactionDateTime
        {
            get => _transactionDateTime;
            set => _transactionDateTime = value;
        }

        public string Remarks
        {
            get => _remarks;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new TransactionException("Remarks (Description) cannot be empty.");
                _remarks = value;
            }
        }
        #endregion

        #region constructors
        public Transaction()
        {
            FromAccountNumber = Guid.Empty;
            ToAccountNumber = Guid.Empty;
            Amount = 0;
            Remarks = "";
            TransactionDateTime = DateTime.MinValue;
        }
        public Transaction(Guid transactionID, Guid fromAccountNumber, Guid toAccountNumber, decimal amount, DateTime transactionDateTime, string remarks)
        {
            TransactionID = transactionID;
            FromAccountNumber = fromAccountNumber;
            ToAccountNumber = toAccountNumber;
            Amount = amount;
            TransactionDateTime = transactionDateTime;
            Remarks = remarks;

        }
        #endregion

        #region method
        public object Clone()
        {
            return new Transaction() { TransactionID = this.TransactionID, Amount = this.Amount, FromAccountNumber = this.FromAccountNumber, Remarks = this.Remarks, ToAccountNumber = this.ToAccountNumber, TransactionDateTime = this.TransactionDateTime };
        }
        #endregion
    }
}
