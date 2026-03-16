using System;
namespace Problem_4
{
    class Vehicle
    {
        public string Brand { get; set; }
        public double RentalRatePerDay { get; set; }

        public virtual double CalculateRental(int days)
        {
            return RentalRatePerDay * days;
        }
    }

    class Car : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total = RentalRatePerDay * days;
            return total + 500;
        }
    }

    class Bike : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total = RentalRatePerDay * days;
            return total - (total * 0.05);
        }
    }

    class Program
    {
        static void Main()
        {
            double rate;
            int days;

            Console.Write("Enter Car Rental Rate Per Day: ");
            rate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Number of Days: ");
            days = Convert.ToInt32(Console.ReadLine());

            Vehicle v = new Car();
            v.RentalRatePerDay = rate;

            Console.WriteLine("Total Rental = " + v.CalculateRental(days));

            Console.ReadKey();
        }
    }
}
