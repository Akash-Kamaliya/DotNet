//How was the password are 
using System.Text.RegularExpressions;

Console.WriteLine("Enter Password and i will tell you its strong or not");
string password = Console.ReadLine();
string check = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
Regex validateGuidRegex = new Regex(check);

if (validateGuidRegex.IsMatch(password))
{
    Console.WriteLine("Strong Password");
}
else
{
    Console.WriteLine("Noob Password");
}