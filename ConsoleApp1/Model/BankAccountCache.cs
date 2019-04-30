using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Model
{
    class BankAccountCache
    {
        public List<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
        public BankAccount LoggedInAccount { get; set; }

        public void createNewUser(String userName, String password)
        {
            if (checkIfUserIdExists(userName))
            {
                throw new Exception("Username already in use.");
            } else
            {
                BankAccount newAccount = new BankAccount(BankAccounts.Count, new User(userName, password));
                BankAccounts.Add(newAccount);
            }
        }

        public void login(String userName, String password)
        {
            BankAccount account = fetchBankAccount(new User(userName, password));
            if (account == null)
            {
                throw new Exception("Invalid user/password combination.");
            }
            else
            {
                LoggedInAccount = account;
            }
        }

        public void logout()
        {
            LoggedInAccount = null;
        }

        public int getCacheSize()
        {
            return BankAccounts.Count;
        }

        public BankAccount fetchBankAccount(User user)
        {
            foreach(BankAccount account in BankAccounts)
            {
                if (account.Customer.Equals(user))
                {
                    return account;
                }
            }
            return null;
        }

        public Boolean checkIfUserIdExists(String userName)
        {
            Boolean result = false;
            foreach (BankAccount account in BankAccounts)
            {
                if (account.Customer.UserName.ToUpper().Equals(userName.ToUpper()))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
