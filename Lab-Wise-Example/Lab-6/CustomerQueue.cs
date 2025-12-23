using System;
using System.Collections.Generic;

class CustomerQueue
{
    Queue<string> customers = new Queue<string>();

    public void Run()
    {
        customers.Enqueue("Amit");
        customers.Enqueue("Rahul");
        customers.Enqueue("Akash");

        Console.WriteLine("Next Customer: " + customers.Peek());
        Console.WriteLine("Serving: " + customers.Dequeue());
        Console.WriteLine("Next Customer: " + customers.Peek());
    }
}
