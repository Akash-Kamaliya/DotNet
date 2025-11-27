//Factorial of Number:
Console.WriteLine("Enter a number to calculate its factorial:");
int number = Convert.ToInt32(Console.ReadLine());
int fact = 1;

for(int i = number;i>0;i--)
{
    fact *= i;
}
Console.WriteLine("Factorial is :" + fact);