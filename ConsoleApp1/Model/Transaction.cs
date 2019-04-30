using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public DateTime Timestamp { get; set; }
        public Decimal Amount { get; set; }

        public Transaction(int transactionId, TransactionTypeEnum transactionType, DateTime timestamp, decimal amount)
        {
            TransactionId = transactionId;
            TransactionType = transactionType;
            Timestamp = timestamp;
            Amount = amount;
        }

        public String prettyTransactionDetails()
        {
            return TransactionType.ToString() + "\t" + Timestamp + "\t" +Amount;
        }
    }
}
