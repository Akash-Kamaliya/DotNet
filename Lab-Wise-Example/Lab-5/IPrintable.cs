using System;

interface IPrintable
{
    void PrintDetails();
}

class Book : IPrintable
{
    public void PrintDetails()
    {
        Console.WriteLine("Book Details Printed");
    }
}

class Magazine : IPrintable
{
    public void PrintDetails()
    {
        Console.WriteLine("Magazine Details Printed");
    }
}
