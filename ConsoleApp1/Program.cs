using ConsoleApp1.Model;
using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        private static BankAccountCache cache = new BankAccountCache();

        static void Main(string[] args)
        {
            Console.WriteLine("**********Worlds Greatest Banking Ledgar(**********");
            Console.WriteLine("Please enter one of the following options.");
            printUserOptions();

            string optionValue = "";
            while (true)
            {
                optionValue = Console.ReadLine();
                parseMenuInput(optionValue);
            }
        }

        private static void printUserOptions()
        {
            Console.WriteLine("Create - create a new user account");
            Console.WriteLine("Login - login to user account");
            Console.WriteLine("Deposit - deposit money into current user account");
            Console.WriteLine("Withdrawal - withdrawal money from user account");
            Console.WriteLine("Balance - display current account balance");
            Console.WriteLine("History - display transaction history");
            Console.WriteLine("Logout - logout from user account");
            Console.WriteLine("Help - see this command list");
        }

        /**
         * Handles user input and calls appropriate methods
         */
        private static void parseMenuInput(String optionValue)
        {
            String input = optionValue.ToUpper();
            switch (input)
            {
                case "CREATE":
                    createNewUser();
                    break;
                case "LOGIN":
                    login();
                    break;
                case "DEPOSIT":
                    deposit();
                    break;
                case "WITHDRAWAL":
                    withdrawal();
                    break;
                case "BALANCE":
                    checkBalance();
                    break;
                case "HISTORY":
                    printHistory();
                    break;
                case "LOGOUT":
                    logout();
                    break;
                case "HELP":
                    printUserOptions();
                    break;
                default: Console.WriteLine("Incorrect option selected.");
                    printUserOptions();
                    break;

            }
        }

        /**
         * Creates a new user
         */
        private static void createNewUser()
        {
            String userName = "";
            String password = "";
          
            while (String.IsNullOrEmpty(userName) || cache.checkIfUserIdExists(userName))
            {
                Console.WriteLine("Please enter userId:");
                userName = Console.ReadLine();
                if (String.IsNullOrEmpty(userName))
                {
                    Console.WriteLine("Blank username is not valid, please try again.");
                } else if (cache.checkIfUserIdExists(userName))
                {
                    Console.WriteLine("Username already exists. Please choose another.");
                }

            }

            while (String.IsNullOrEmpty(password))
            {
                Console.WriteLine("Please enter password:");
                password = Console.ReadLine();
                if (String.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Blank password is not valid, please try again.");
                }
            }

            cache.createNewUser(userName, password);
            Console.WriteLine("Account successfully created.\n");
        }

        /**
         * loads correct bankAccount into memory
         */
        private static void login()
        {
            if(cache.getCacheSize() <= 0)
            {
                Console.WriteLine("There are no existing bank accounts. Please create an account and try again.");
                return;
            }

            String userName = "";
            String password = "";

            Console.WriteLine("Please enter userId:");
            userName = Console.ReadLine();

            Console.WriteLine("Please enter password:");
            password = Console.ReadLine();

            try
            {
                cache.login(userName, password);
                Console.WriteLine("You are now logged in as: " + userName + "\n");
            }
            catch
            {
                Console.WriteLine("Incorrect username/password. Please enter a valid login.");
                login();
            }
        }

        private static void logout()
        {
            if(cache.LoggedInAccount != null)
            {
                cache.logout();
                Console.WriteLine("You are now logged out.");
            }
            else
            {
                Console.WriteLine("You are not currently logged in.");
            }
        }

        /**
         * Adds money to current user account. Adds to transaction history.
         */
        private static void deposit()
        {
            if(cache.LoggedInAccount != null)
            {
                String depositAmount = "";
                Regex pattern = new Regex("^[0-9]{1,3}(?:,?[0-9]{3})*\\.[0-9]{2}$");
                decimal depositDecimal;

                while (!pattern.IsMatch(depositAmount) || !Decimal.TryParse(depositAmount, out depositDecimal))
                {
                    Console.WriteLine("Please enter an amount to deposit with any amount of dollars followed by cents. Ex: 4,123.56");
                    depositAmount = Console.ReadLine();
                }
                cache.LoggedInAccount.deposit(depositDecimal);
            } else
            {
                Console.WriteLine("Please login to make a deposit.");
            }
        }

        /**
         * Removes money to current user account. Adds to transaction history.
         */
        private static void withdrawal()
        {
            if (cache.LoggedInAccount != null)
            {
                String withdrawalAmount = "";
                Regex pattern = new Regex("^[0-9]{1,3}(?:,?[0-9]{3})*\\.[0-9]{2}$");
                decimal withdrawalDecimal;

                while (!pattern.IsMatch(withdrawalAmount) || !Decimal.TryParse(withdrawalAmount, out withdrawalDecimal))
                {
                    Console.WriteLine("Please enter an amount to withdrawal with any amount of dollars followed by cents. Ex: 4,123.56");
                    withdrawalAmount = Console.ReadLine();
                }
                cache.LoggedInAccount.withdrawal(withdrawalDecimal);
            }
            else
            {
                Console.WriteLine("Please login to make a withdrawal.");
            }
        }

        /**
         * Checks current balance
         */
        private static void checkBalance()
        {
            if(cache.LoggedInAccount != null)
            {
                Console.WriteLine("Your current balance is: $" + cache.LoggedInAccount.Amount);
            }
            else
            {
                Console.WriteLine("Please login to check your balance.");
            }
        }

        /**
        * Prints transaction history
        */
        private static void printHistory()
        {
            if (cache.LoggedInAccount != null)
            {
                foreach(Transaction transaction in cache.LoggedInAccount.TransactionHistory){
                    Console.WriteLine(transaction.prettyTransactionDetails());
                }
            }
            else
            {
                Console.WriteLine("Please login to check your print transaction history.");
            }
        }
    }
}
