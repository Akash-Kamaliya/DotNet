using System;

abstract class Appliance
{
    public abstract void TurnOn();
}

class Fan : Appliance
{
    public override void TurnOn()
    {
        Console.WriteLine("Fan is ON");
    }
}

class Light : Appliance
{
    public override void TurnOn()
    {
        Console.WriteLine("Light is ON");
    }
}
