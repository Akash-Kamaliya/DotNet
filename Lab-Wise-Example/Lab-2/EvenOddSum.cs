using System;

class EvenOddSum
{
    public void Calculate()
    {
        Console.Write("Enter limit: ");
        int limit = Convert.ToInt32(Console.ReadLine());

        int evenSum = 0, oddSum = 0;

        for (int i = 1; i <= limit; i++)
        {
            if (i % 2 == 0) evenSum += i;
            else oddSum += i;
        }

        Console.WriteLine($"Even Sum: {evenSum}");
        Console.WriteLine($"Odd Sum: {oddSum}");
    }
}
