using System;

class Rectangle
{
    double length, breadth;

    public Rectangle(double l, double b)
    {
        length = l;
        breadth = b;
    }

    public double Area()
    {
        return length * breadth;
    }
}
