using System;
using System.Collections.Generic;

class HospitalQueue
{
    Queue<string> normal = new Queue<string>();
    Queue<string> emergency = new Queue<string>();

    public void Run()
    {
        normal.Enqueue("Patient1");
        emergency.Enqueue("Patient2");
        normal.Enqueue("Patient3");

        if (emergency.Count > 0)
            Console.WriteLine("Serving: " + emergency.Dequeue());
        else
            Console.WriteLine("Serving: " + normal.Dequeue());
    }
}
