using System;

class EmployeeSalary
{
    public void CalculateSalary()
    {
        Console.Write("Enter Basic Salary: ");
        double basic = Convert.ToDouble(Console.ReadLine());

        double hra = basic * 0.10;
        double da = basic * 0.15;
        double deduction = basic * 0.08;

        double gross = basic + hra + da;
        double net = gross - deduction;

        Console.WriteLine($"Gross Salary: {gross}");
        Console.WriteLine($"Net Salary: {net}");
    }
}
