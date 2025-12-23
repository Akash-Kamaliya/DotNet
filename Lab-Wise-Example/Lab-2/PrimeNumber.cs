using System;

class PrimeNumber
{
    public void Check()
    {
        Console.Write("Enter number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        bool isPrime = true;

        if (n <= 1) isPrime = false;

        for (int i = 2; i <= n / 2; i++)
        {
            if (n % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        Console.WriteLine(isPrime ? "Prime Number" : "Not Prime");
    }
}
