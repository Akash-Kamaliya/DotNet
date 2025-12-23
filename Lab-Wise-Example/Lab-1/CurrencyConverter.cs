using System;

class CurrencyConverter
{
    public void Convert2()
    {
        Console.Write("Enter amount in INR: ");
        double inr = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("USD: " + (inr * 0.012));
        Console.WriteLine("EUR: " + (inr * 0.011));
        Console.WriteLine("GBP: " + (inr * 0.009));
    }
}
