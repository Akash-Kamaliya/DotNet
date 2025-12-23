using System;

class DivideNumbers
{
    public void Divide()
    {
        try
        {
            Console.Write("Enter first number: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Result: " + (a / b));
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero");
        }
    }
}
