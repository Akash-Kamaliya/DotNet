using System;

class FibonacciSeries
{
    public void Print()
    {
        Console.Write("Enter terms: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int a = 0, b = 1;

        for (int i = 1; i <= n; i++)
        {
            Console.Write(a + " ");
            int c = a + b;
            a = b;
            b = c;
        }
    }
}
