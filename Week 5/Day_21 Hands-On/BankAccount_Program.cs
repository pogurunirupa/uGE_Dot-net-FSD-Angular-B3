using System;
namespace Problem_1
{
    class BankAccount
    {
        private int accountNumber;
        private double balance;

        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public double Balance
        {
            get { return balance; }
            private set { balance = value; }
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine("Balance after deposit: " + balance);
            }
            else
            {
                Console.WriteLine("Invalid deposit amount");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid withdrawal amount");
            }
            else if (amount > balance)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                balance -= amount;
                Console.WriteLine("Balance after withdrawal: " + balance);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            BankAccount acc = new BankAccount();

            Console.Write("Enter Account Number: ");
            acc.AccountNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Deposit Amount: ");
            double deposit = Convert.ToDouble(Console.ReadLine());
            acc.Deposit(deposit);

            Console.Write("Enter Withdraw Amount: ");
            double withdraw = Convert.ToDouble(Console.ReadLine());
            acc.Withdraw(withdraw);

            Console.WriteLine("Current Balance = " + acc.Balance);

            Console.ReadKey();
        }
    }
}
