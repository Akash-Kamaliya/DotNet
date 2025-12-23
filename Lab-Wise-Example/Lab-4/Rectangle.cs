using System;

class Rectangle : Shape
{
    double length, breadth;
    public Rectangle(double l, double b)
    {
        length = l;
        breadth = b;
    }

    public override double CalculateArea()
    {
        return length * breadth;
    }
}
