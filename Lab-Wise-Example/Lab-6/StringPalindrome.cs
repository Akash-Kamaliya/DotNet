using System;

class StringPalindrome
{
    public void Check()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine().Replace(" ", "").ToLower();

        char[] arr = input.ToCharArray();
        Array.Reverse(arr);

        string rev = new string(arr);

        Console.WriteLine(input == rev ? "Palindrome" : "Not Palindrome");
    }
}
