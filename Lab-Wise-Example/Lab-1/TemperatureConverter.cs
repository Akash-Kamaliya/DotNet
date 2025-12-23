using System;

class TemperatureConverter
{
    public void Convert1()
    {
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");
        Console.Write("Choose option: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter temperature: ");
        double temp = Convert.ToDouble(Console.ReadLine());

        if (choice == 1)
            Console.WriteLine("Result: " + ((temp * 9 / 5) + 32));
        else
            Console.WriteLine("Result: " + ((temp - 32) * 5 / 9));
    }
}
