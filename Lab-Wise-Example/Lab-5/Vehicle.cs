using System;

class Vehicle
{
    public void Type()
    {
        Console.WriteLine("This is a vehicle");
    }
}

class Car : Vehicle
{
    public void CarType()
    {
        Console.WriteLine("This is a car");
    }
}

class ElectricCar : Car
{
    public void ElectricType()
    {
        Console.WriteLine("This is an electric car");
    }
}
