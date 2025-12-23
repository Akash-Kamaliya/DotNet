using System;
using System.Collections.Generic;

class UniqueEmails
{
    public void Run()
    {
        HashSet<string> emails = new HashSet<string>();

        emails.Add("a@gmail.com");
        emails.Add("b@gmail.com");
        emails.Add("a@gmail.com");

        Console.WriteLine("Total Unique Emails: " + emails.Count);
    }
}
