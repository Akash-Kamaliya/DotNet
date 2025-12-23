using System;

class Magazine : LibraryItem
{
    public Magazine(string t, string a) : base(t, a) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Magazine: {Title}, Author: {Author}");
    }
}
