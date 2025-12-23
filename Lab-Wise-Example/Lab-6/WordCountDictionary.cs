using System;
using System.Collections.Generic;

class WordCountDictionary
{
    public void Count()
    {
        Console.Write("Enter sentence: ");
        string[] words = Console.ReadLine().ToLower().Split(' ');

        Dictionary<string, int> dict = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (dict.ContainsKey(word))
                dict[word]++;
            else
                dict[word] = 1;
        }

        foreach (var item in dict)
            Console.WriteLine($"{item.Key} : {item.Value}");
    }
}
