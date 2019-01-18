using System;
namespace IntroToClasses
{
    public class Transaction
    {

        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        // constructor 
        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }

    }
}
