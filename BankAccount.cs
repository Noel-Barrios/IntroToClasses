using System;
using System.Collections.Generic;
namespace IntroToClasses
{
    public class BankAccount
    {
        // REQUIREMENTS:
        //It has a 10-digit number that uniquely identifies the bank account.
        //It has a string that stores the name or names of the owners.
        //The balance can be retrieved.
        //It accepts deposits.
        //It accepts withdrawals.
        //The initial balance must be positive.
        //Withdrawals cannot result in a negative balance.



        // lets create a collection of Transaction objects.
        private List<Transaction> allTransactions = new List<Transaction>();
        public static int acctNumberSeed = 1213;
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        // Private: means only memebers of the same class are allowed to access.
        // When we use the private keyword it means it can only be accessed by code 
        // inside the BankAccount class.  It's a way of seperating the public responsibilities 
        // (like having an account number) from the private implementation (how account numbers are generated).
        // It is also static, which means it is shared by all of the BankAccount objects.
        // The Static keyword means that the variable or function is shared between all instances of that class
        // as it belongs to the type, not the actual objects themselves.  So if you have a variable: private static
        // int i = 0; and you increment it (i++) in one instance, the change will be reflected in all instances.
        private static int accountNumberSeed = 1234567890;

        // creating a new object of the BankAccount type means defining a constructor that assigns values.
        // A constructor is a member that has the same name as the class.
        // It is used to initialize objects of that class types.  
        public BankAccount(string name, decimal initialBalance)
        { 
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            //this.Balance = initialBalance;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if(Balance - amount <= 0)
            {
                // the throw statement strhows an exception.  Execution of the current block ends, and control transfers to the first
                // matching catch block found in the call stack.  
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);

        }
    }

}
