using System;

namespace Lab_3
{
    class Program
    {
        static void Main()
            {
                Student s1 = new Student("Akash", 1, 88);
                Student s2 = new Student("Rahul", 2, 92);
                s1.Display();
                s2.Display();

                Rectangle r = new Rectangle(10, 5);
                Console.WriteLine("Area: " + r.Area());

                new DivideNumbers().Divide();

                try
                {
                    BankAccount acc = new BankAccount(101, "Akash", 5000);
                    acc.Deposit(2000);
                    acc.Withdraw(9000);
                    acc.Display();
                }
                catch (AccountException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                new Person().Display();
                new Person("Akash").Display();
                new Person("Akash", 19, "Rajkot").Display();

                Employee e = new Employee(1, "Akash", 30000);
                e.Display();

                try
                {
                    ShoppingCart cart = new ShoppingCart("Laptop", 50000, 1);
                    Console.WriteLine("Total: " + cart.Total());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                try
                {
                    CarRental car = new CarRental("SUV", 1500, 3);
                    Console.WriteLine("Rent: " + car.CalculateRent());

                    new FlightTicket("Akash", "AI-202", 4500);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
    }
}