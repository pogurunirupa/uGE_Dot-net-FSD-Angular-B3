using System;
namespace Problem_3
{
    class Product
    {
        private double price;

        public string Name { get; set; }

        public double Price
        {
            get { return price; }
            set
            {
                if (value >= 0)
                    price = value;
                else
                    Console.WriteLine("Invalid price");
            }
        }

        public virtual double CalculateDiscount()
        {
            return Price;
        }
    }

    class Electronics : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.05);
        }
    }

    class Clothing : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.15);
        }
    }

    class Program
    {
        static void Main()
        {
            double price;

            Console.Write("Enter Electronics Price: ");
            price = Convert.ToDouble(Console.ReadLine());

            Product p = new Electronics();
            p.Price = price;

            Console.WriteLine("Final Price after discount = " + p.CalculateDiscount());
            Console.ReadKey();  
        }
    }
}
