//celcius to farenheit and farenheit to celcius
Console.WriteLine("||   Temparature Converter   ||");
Console.WriteLine("Enter 1 for Celcius to Farenheit : ");
Console.WriteLine("Enter 2 for Farenheit to Celcius : ");
int choice = Convert.ToInt32(Console.ReadLine());
if(choice == 1)
{
    Console.WriteLine("Enter Degree Celcius: ");
    double c1 = Convert.ToDouble(Console.ReadLine());
    double f2 = (c1 * 9 / 5) + 32;
    Console.WriteLine(c1 + " Celcius = "+ f2 +" Farenheit");
}
else if(choice == 2)
{
    Console.WriteLine("Enter Degree Farenheit: ");
    double f1 = Convert.ToDouble(Console.ReadLine());
    double c2 = ((f1 - 32)*5)/9;
    Console.WriteLine(f1 + " Farenheit = "+ c2 +" Celcius");
}
