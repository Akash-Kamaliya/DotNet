using System;

class Book : LibraryItem
{
    public Book(string t, string a) : base(t, a) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Book: {Title}, Author: {Author}");
    }
}
