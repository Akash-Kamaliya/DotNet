using System;

interface IMovable
{
    void Move();
}

interface ISound
{
    void MakeSound();
}

class Robot : IMovable, ISound
{
    public void Move()
    {
        Console.WriteLine("Robot is moving");
    }

    public void MakeSound()
    {
        Console.WriteLine("Robot makes sound");
    }
}
