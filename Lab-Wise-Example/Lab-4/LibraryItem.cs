using System;

class LibraryItem
{
    protected string Title;
    protected string Author;

    public LibraryItem(string t, string a)
    {
        Title = t;
        Author = a;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"{Title} by {Author}");
    }
}
