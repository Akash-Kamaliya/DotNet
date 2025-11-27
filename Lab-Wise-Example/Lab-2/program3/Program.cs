//Grade Selector
Console.WriteLine("Enter Your Marks:");
int marks = Convert.ToInt32(Console.ReadLine());

if(marks >= 90)
{
    Console.WriteLine("Congratulation Your Grade is A");
}
else if(marks >=80 && marks < 90)
{
    Console.WriteLine("Congratulation Your Grade is B");
}
else if (marks >= 70 && marks < 80)
{
    Console.WriteLine("Congratulation Your Grade is C");
}
else if (marks >= 60 && marks < 70)
{
    Console.WriteLine("Congratulation Your Grade is D");
}
else if (marks >= 50 && marks < 60)
{
    Console.WriteLine("Congratulation Your Grade is E");
}
else if (marks >= 0 && marks < 50)
{
    Console.WriteLine("Sorry You are Fail");
}
else
{
    Console.WriteLine("please enter Valid Number");
}