using System;

class PalindromeNumber
{
    public void Check()
    {
        Console.Write("Enter number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int temp = n, rev = 0;

        while (temp > 0)
        {
            rev = rev * 10 + (temp % 10);
            temp /= 10;
        }

        Console.WriteLine(n == rev ? "Palindrome" : "Not Palindrome");
    }
}
