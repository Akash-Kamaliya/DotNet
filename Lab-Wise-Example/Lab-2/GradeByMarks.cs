using System;

class GradeByMarks
{
    public void CalculateGrade()
    {
        Console.Write("Enter total marks: ");
        int marks = Convert.ToInt32(Console.ReadLine());

        if (marks >= 75) Console.WriteLine("Grade: A");
        else if (marks >= 60) Console.WriteLine("Grade: B");
        else if (marks >= 45) Console.WriteLine("Grade: C");
        else if (marks >= 35) Console.WriteLine("Grade: D");
        else Console.WriteLine("Fail");
    }
}
