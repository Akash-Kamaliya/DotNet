using System;

class GeometricShapes
{
    public void Calculate()
    {
        Console.WriteLine("1. Rectangle");
        Console.WriteLine("2. Circle");
        Console.WriteLine("3. Triangle");
        Console.Write("Choose shape: ");
        int ch = Convert.ToInt32(Console.ReadLine());

        switch (ch)
        {
            case 1:
                Console.Write("Length: ");
                double l = Convert.ToDouble(Console.ReadLine());
                Console.Write("Breadth: ");
                double b = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Area: " + (l * b));
                Console.WriteLine("Perimeter: " + (2 * (l + b)));
                break;

            case 2:
                Console.Write("Radius: ");
                double r = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Area: " + (Math.PI * r * r));
                Console.WriteLine("Perimeter: " + (2 * Math.PI * r));
                break;

            case 3:
                Console.Write("Side: ");
                double s = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Perimeter: " + (3 * s));
                break;
        }
    }
}
