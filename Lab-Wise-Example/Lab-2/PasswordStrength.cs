using System;

class PasswordStrength
{
    public void Check()
    {
        Console.Write("Enter password: ");
        string pwd = Console.ReadLine();

        bool upper = false, lower = false, digit = false, special = false;

        foreach (char c in pwd)
        {
            if (char.IsUpper(c)) upper = true;
            else if (char.IsLower(c)) lower = true;
            else if (char.IsDigit(c)) digit = true;
            else special = true;
        }

        if (pwd.Length >= 8 && upper && lower && digit && special)
            Console.WriteLine("Strong Password");
        else
            Console.WriteLine("Weak Password");
    }
}
