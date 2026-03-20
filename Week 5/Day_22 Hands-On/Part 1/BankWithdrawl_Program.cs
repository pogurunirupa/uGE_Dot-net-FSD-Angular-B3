using System;
namespace BankWithdrawl
{
   
    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    class BankAccount
    {
        private double balance;

        public BankAccount(double initialBalance)
        {
            balance = initialBalance;
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
            }

            balance -= amount;
            Console.WriteLine("Withdrawal successful! Remaining balance: " + balance);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Enter initial balance: ");
            double bal = double.Parse(Console.ReadLine());

            BankAccount account = new BankAccount(bal);

            Console.Write("Enter withdrawal amount: ");
            double amount = double.Parse(Console.ReadLine());

            try
            {
                account.Withdraw(amount);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction completed.");
            }
        }
    }
}
