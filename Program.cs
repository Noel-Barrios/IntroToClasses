using System;

namespace IntroToClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Squancho", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with ${account.Balance} initial balance.");

            account.MakeWithdrawal(500, DateTime.Now, "Rent Payment");
            Console.WriteLine($"Your balance is now {account.Balance}");

            account.MakeDeposit(100, DateTime.Now, "friend paid me back");
            Console.WriteLine($"Your balance is now {account.Balance}");


            try
            {
                var invalidACcount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }


            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString()); 
            }

        }
    }
}
