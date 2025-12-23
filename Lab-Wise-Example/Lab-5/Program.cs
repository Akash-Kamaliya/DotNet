using System;

namespace Lab_5
{

    class Program
    {
        static void Main()
        {
            Dog d = new Dog();
            d.Eat();
            d.Bark();

            ElectricCar ec = new ElectricCar();
            ec.Type();
            ec.CarType();
            ec.ElectricType();

            Shape s1 = new Circle(5);
            Shape s2 = new Rectangle(4, 6);
            Console.WriteLine("Circle Area: " + s1.Area());
            Console.WriteLine("Rectangle Area: " + s2.Area());

            Appliance a1 = new Fan();
            Appliance a2 = new Light();
            a1.TurnOn();
            a2.TurnOn();

            IPrintable p1 = new Book();
            IPrintable p2 = new Magazine();
            p1.PrintDetails();
            p2.PrintDetails();

            Robot r = new Robot();
            r.Move();
            r.MakeSound();

            try
            {
                Payment pay1 = new CreditCardPayment();
                Payment pay2 = new UPIPayment();
                pay1.MakePayment(500);
                pay2.MakePayment(300);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Employee e1 = new Manager("Akash", 50000);
            Employee e2 = new Developer("Rahul", 40000);
            Console.WriteLine("Manager Bonus: " + e1.CalculateBonus());
            Console.WriteLine("Developer Bonus: " + e2.CalculateBonus());
        }
    }

}