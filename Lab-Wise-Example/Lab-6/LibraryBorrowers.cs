using System;
using System.Collections.Generic;

class LibraryBorrowers
{
    Dictionary<string, Queue<string>> data = new Dictionary<string, Queue<string>>();

    public void Run()
    {
        data["C#"] = new Queue<string>();
        data["C#"].Enqueue("Akash");
        data["C#"].Enqueue("Rahul");

        foreach (var book in data)
        {
            Console.WriteLine("Book: " + book.Key);
            foreach (string user in book.Value)
                Console.WriteLine("Borrower: " + user);
        }
    }
}
