using System;

class Student
{
    string Name;
    int RollNo;
    double Marks;

    public Student(string name, int roll, double marks)
    {
        Name = name;
        RollNo = roll;
        Marks = marks;
    }

    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Roll No: {RollNo}, Marks: {Marks}");
    }
}
