using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class BankAccount
    {
        public int BankAccountId {get; set; }
        public User Customer { get; set; }
        public decimal Amount { get; set; }
        public List<Transaction> TransactionHistory { get; set; }

        public BankAccount(int bankAccountId, User customer)
        {
            this.BankAccountId = bankAccountId;
            this.Customer = customer;
            this.Amount = 0;
            this.TransactionHistory = new List<Transaction>();
        }

        public void deposit(decimal amount)
        {
            TransactionHistory.Add(new Transaction(generateTransactionId(), TransactionTypeEnum.DEPOSIT, DateTime.Now, amount));
            this.Amount += amount;
        }

        /**
         * This method will withdrawal the given amount from this account. Either positive or negative amounts will be deducted from current balance.
         */
        public void withdrawal(decimal amount)
        {
            decimal tempAmount = amount < 0 ? amount * -1 : amount;
            TransactionHistory.Add(new Transaction(generateTransactionId(), TransactionTypeEnum.WITHDRAWAL, DateTime.Now, tempAmount));
            this.Amount -= amount;
        }

        private int generateTransactionId()
        {
            String bankAccId = BankAccountId.ToString() + TransactionHistory.Count.ToString();
            return int.Parse(bankAccId);
        }
    }
}
