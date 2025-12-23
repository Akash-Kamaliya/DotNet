using System;


namespace Lab_4
{
    class Program
    {
        static void Main()
        {
            Calculator c = new Calculator();
            Console.WriteLine(c.Add(2, 3));
            Console.WriteLine(c.Add(2, 3, 4));
            Console.WriteLine(c.Add(2.5, 3.5));

            EmployeeOverload eo = new EmployeeOverload();
            eo.Display("Akash");
            eo.Display("Akash", 19);
            eo.Display("Akash", 19, 30000);

            AccessModifierDemo amd = new AccessModifierDemo();
            amd.Show();

            Animal a1 = new Dog();
            Animal a2 = new Cat();
            a1.Sound();
            a2.Sound();

            Shape s1 = new Circle(5);
            Shape s2 = new Rectangle(10, 4);
            Console.WriteLine("Circle Area: " + s1.CalculateArea());
            Console.WriteLine("Rectangle Area: " + s2.CalculateArea());

            BankTransaction bt = new BankTransaction();
            bt.Transfer(2000);
            bt.Transfer(1000, "Rent");

            LibraryItem li1 = new Book("C# Basics", "Akash");
            LibraryItem li2 = new Magazine("Tech Today", "Team");
            li1.DisplayInfo();
            li2.DisplayInfo();

            Customer rc = new RegularCustomer(10000);
            Customer pc = new PremiumCustomer(10000);
            Console.WriteLine("Regular Bill: " + rc.CalculateBill());
            Console.WriteLine("Premium Bill: " + pc.CalculateBill());
        }
    }

}