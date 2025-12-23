using System;

class GradeCalculator
{
    public void CalculateGrade()
    {
        int total = 0;
        for (int i = 1; i <= 5; i++)
        {
            Console.Write($"Enter marks of subject {i}: ");
            total += Convert.ToInt32(Console.ReadLine());
        }

        double percent = total / 5.0;
        Console.WriteLine("Percentage: " + percent);

        if (percent >= 75) Console.WriteLine("Grade: A");
        else if (percent >= 60) Console.WriteLine("Grade: B");
        else if (percent >= 45) Console.WriteLine("Grade: C");
        else Console.WriteLine("Fail");
    }
}
