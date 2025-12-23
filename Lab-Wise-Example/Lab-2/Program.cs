using System;

namespace Lab_1
{
    public class Program
    {
        static void Main(string [] args)
        {
            new MultiplicationTable().PrintTable();
            new CharacterCounter().Count();
            new GradeByMarks().CalculateGrade();
            new EvenOddSum().Calculate();
            new Factorial().Calculate();
            new PasswordStrength().Check();
            new PrimeNumber().Check();
            new ReverseNumber().Reverse();
            new PalindromeNumber().Check();
            new FibonacciSeries().Print();
        }
    }
}