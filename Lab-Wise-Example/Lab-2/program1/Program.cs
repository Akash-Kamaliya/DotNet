//multyplication table 
Console.WriteLine("Enter number to get multyplication table");
int number = Convert.ToInt32(Console.ReadLine());

for(int i = 1; i<=10; i++)
{
    Console.WriteLine(number + "X" + i + "=" + (number * i));
}
