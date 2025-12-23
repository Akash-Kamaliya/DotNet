using System;

class Factorial
{
    public void Calculate()
    {
        Console.Write("Enter number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        long fact = 1;
        for (int i = 1; i <= n; i++)
            fact *= i;

        Console.WriteLine("Factorial: " + fact);
    }
}
