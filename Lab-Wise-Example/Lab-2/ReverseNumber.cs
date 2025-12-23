using System;

class ReverseNumber
{
    public void Reverse()
    {
        Console.Write("Enter number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int rev = 0;

        while (n > 0)
        {
            rev = rev * 10 + (n % 10);
            n /= 10;
        }

        Console.WriteLine("Reversed Number: " + rev);
    }
}
