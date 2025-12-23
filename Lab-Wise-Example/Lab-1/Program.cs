using System;

namespace Lab_1
{
    public class Program
    {
        static void Main(string [] args)
        {
            PrintPersonalDetails q1 = new PrintPersonalDetails();
            q1.Display();

            TwoNumbers q2 = new TwoNumbers();
            q2.DisplayNumbers();

            NameCountry q3 = new NameCountry();
            q3.Greet();

            TemperatureConverter q4 = new TemperatureConverter();
            q4.Convert1();

            EmployeeSalary q5 = new EmployeeSalary();
            q5.CalculateSalary();

            GeometricShapes q6 = new GeometricShapes();
            q6.Calculate();

            GradeCalculator q7 = new GradeCalculator();
            q7.CalculateGrade();

            CurrencyConverter q8 = new CurrencyConverter();
            q8.Convert2();

            DiscountCalculator q9 = new DiscountCalculator();
            q9.Calculate();
        }
    }
}