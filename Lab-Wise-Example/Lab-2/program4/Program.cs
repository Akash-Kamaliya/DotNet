//Take Limit and Calculate even and odd number sum between the limit
Console.WriteLine("Enter the Starting Point:");
int start = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the Ending Point:");
int end = Convert.ToInt32(Console.ReadLine());
int evenSum = 0;
int oddSum = 0;
for (int i = start; i <= end; i++)
{
    if (i % 2 == 0)
    {
        evenSum += i;
    }
    else
    {
        oddSum += i;
    }
}
Console.WriteLine("Even Number Sum between the limit :"+evenSum);
Console.WriteLine("odd Number Sum between the limit :"+oddSum);
