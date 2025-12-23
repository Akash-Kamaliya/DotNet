using System;
using System.Collections.Generic;

class RecentTasks
{
    Stack<string> tasks = new Stack<string>();

    public void Run()
    {
        tasks.Push("Study C#");
        tasks.Push("Complete Lab");
        tasks.Push("Push to GitHub");

        Console.WriteLine("Most Recent Task: " + tasks.Peek());
        Console.WriteLine("Undo Task: " + tasks.Pop());
        Console.WriteLine("Now Recent Task: " + tasks.Peek());
    }
}
