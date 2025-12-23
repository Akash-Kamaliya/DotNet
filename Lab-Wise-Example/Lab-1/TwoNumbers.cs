using System;

class TwoNumbers
{
    public void DisplayNumbers()
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"First Number: {a}, Second Number: {b}");
    }
}
