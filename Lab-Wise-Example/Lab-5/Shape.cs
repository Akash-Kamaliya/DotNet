using System;

class Shape
{
    public virtual double Area()
    {
        return 0;
    }
}

class Circle : Shape
{
    double r;
    public Circle(double radius) => r = radius;

    public override double Area()
    {
        return Math.PI * r * r;
    }
}

class Rectangle : Shape
{
    double l, b;
    public Rectangle(double length, double breadth)
    {
        l = length;
        b = breadth;
    }

    public override double Area()
    {
        return l * b;
    }
}
