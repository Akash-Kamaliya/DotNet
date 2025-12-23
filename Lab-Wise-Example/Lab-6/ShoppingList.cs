using System;
using System.Collections.Generic;

class ShoppingList
{
    List<string> items = new List<string>();

    public void Run()
    {
        AddItem("Milk");
        AddItem("Bread");
        AddItem("Milk");

        Console.WriteLine("Shopping List:");
        foreach (string item in items)
            Console.WriteLine(item);
    }

    void AddItem(string item)
    {
        if (!items.Contains(item))
            items.Add(item);
    }
}
