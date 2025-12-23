using System;

class CharacterCounter
{
    public void Count()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();

        int digits = 0, alphabets = 0, special = 0;

        foreach (char c in input)
        {
            if (char.IsDigit(c)) digits++;
            else if (char.IsLetter(c)) alphabets++;
            else special++;
        }

        Console.WriteLine($"Alphabets: {alphabets}");
        Console.WriteLine($"Digits: {digits}");
        Console.WriteLine($"Special Characters: {special}");
    }
}
