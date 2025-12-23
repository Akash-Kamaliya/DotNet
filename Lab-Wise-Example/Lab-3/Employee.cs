using System;

class Employee
{
    int empID;
    string empName;
    double salary;

    public Employee(int id, string name, double sal)
    {
        empID = id;
        empName = name;
        salary = sal;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {empID}, Name: {empName}, Salary: {salary}");
    }
}
