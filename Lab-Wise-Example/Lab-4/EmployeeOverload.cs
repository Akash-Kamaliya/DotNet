using System;

class EmployeeOverload
{
    public void Display(string name)
    {
        Console.WriteLine($"Name: {name}");
    }

    public void Display(string name, int age)
    {
        Console.WriteLine($"Name: {name}, Age: {age}");
    }

    public void Display(string name, int age, double salary)
    {
        Console.WriteLine($"Name: {name}, Age: {age}, Salary: {salary}");
    }
}
