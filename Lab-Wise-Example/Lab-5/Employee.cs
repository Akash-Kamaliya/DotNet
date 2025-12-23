using System;

abstract class Employee
{
    public string Name;
    public double Salary;

    public Employee(string n, double s)
    {
        Name = n;
        Salary = s;
    }

    public abstract double CalculateBonus();
}

class Manager : Employee
{
    public Manager(string n, double s) : base(n, s) { }

    public override double CalculateBonus()
    {
        return Salary * 0.20;
    }
}

class Developer : Employee
{
    public Developer(string n, double s) : base(n, s) { }

    public override double CalculateBonus()
    {
        return Salary * 0.10;
    }
}

