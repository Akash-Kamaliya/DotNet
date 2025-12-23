using System;

class NameCountry
{
    public void Greet()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter country name: ");
        string country = Console.ReadLine();

        Console.WriteLine($"Hello {name} from country {country}");
    }
}
