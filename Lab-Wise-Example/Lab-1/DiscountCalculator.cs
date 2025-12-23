using System;

class DiscountCalculator
{
    public void Calculate()
    {
        Console.Write("Enter purchase amount: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        double discount = 0;

        if (amount < 5000) discount = amount * 0.05;
        else if (amount <= 10000) discount = amount * 0.10;
        else discount = amount * 0.15;

        Console.WriteLine("Discount: " + discount);
        Console.WriteLine("Final Amount: " + (amount - discount));
    }
}
