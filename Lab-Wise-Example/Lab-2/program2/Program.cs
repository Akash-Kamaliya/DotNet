//develoap program that count hoe many digit alphabat and special character 
Console.WriteLine("Program to count digit Character number");
Console.WriteLine("Enter String to count :");
String str = Console.ReadLine();
char[] c = str.ToCharArray();

int d = 0;
int lc = 0;
int uc = 0;
int sc = 0;
int ws = 0;

foreach (char ch in c)
{
   if (Char.IsDigit(ch))
   {
       d++;
   }
   else if (Char.IsLower(ch))
   {
       lc++;
   }
   else if (Char.IsUpper(ch))
   {
       uc++;
   }
   else if (Char.IsPunctuation(ch))
   {
       sc++;
   }
   else if (Char.IsWhiteSpace(ch))
   {
       ws++;
   }
}

Console.WriteLine("Digit : " + d);
Console.WriteLine("Lower Case Character : " + lc);
Console.WriteLine("Upper Case Character : " + uc);
Console.WriteLine("Special Character : " + sc);
Console.WriteLine("White Space : " + ws);


//develoap program that count hoe many digit alphabat and special character 
// using System.Globalization;

// Console.WriteLine("Program to count digit Character number");
// Console.WriteLine("Enter String to count :");
// String str = Console.ReadLine();
// char[] c = str.ToCharArray();

// int d = 0;
// int lc = 0;
// int uc = 0;
// int sc = 0;
// int ws = 0;

// foreach (char ch in c)
// {
//     if (Char.GetUnicodeCategory(ch) == UnicodeCategory.LowercaseLetter)
//     {
//         lc++;

//     }
//     else if (Char.GetUnicodeCategory(ch) == UnicodeCategory.UppercaseLetter)
//     {
//         uc++;
//     }
//     else if (Char.GetUnicodeCategory(ch) == UnicodeCategory.DecimalDigitNumber)
//     {
//         d++;
//     }
//     else if (Char.GetUnicodeCategory(ch) == UnicodeCategory.SpaceSeparator)
//     {
//         ws++;
//     }
//     else
//     {
//         sc++;
//     }
// }

// Console.WriteLine("Digit : " + d);
// Console.WriteLine("Lower Case Character : " + lc);
// Console.WriteLine("Upper Case Character : " + uc);
// Console.WriteLine("Special Character : " + sc);
// Console.WriteLine("White Space : " + ws);