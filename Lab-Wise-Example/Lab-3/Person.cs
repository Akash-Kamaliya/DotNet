using System;

class Person
{
    string name;
    int age;
    string city;

    public Person()
    {
        name = "Unknown";
        age = 0;
        city = "N/A";   
    }

    public Person(string n)
    {
        name = n;
    }

    public Person(string n, int a, string c)
    {
        name = n;
        age = a;
        city = c;
    }

    public void Display()
    {
        Console.WriteLine($"{name}, {age}, {city}");
    }
}
