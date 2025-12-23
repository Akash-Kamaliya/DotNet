using System;

class AccessModifierDemo
{
    public string PublicData = "Public";
    private string PrivateData = "Private";
    protected string ProtectedData = "Protected";
    internal string InternalData = "Internal";

    public void Show()
    {
        Console.WriteLine(PublicData);
        Console.WriteLine(PrivateData);
        Console.WriteLine(ProtectedData);
        Console.WriteLine(InternalData);
    }
}
