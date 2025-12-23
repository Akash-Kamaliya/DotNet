using System;

class WordFrequency
{
    public void Count()
    {
        Console.Write("Enter sentence: ");
        string[] words = Console.ReadLine().Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            int count = 1;
            if (words[i] == "0") continue;

            for (int j = i + 1; j < words.Length; j++)
            {
                if (words[i] == words[j])
                {
                    count++;
                    words[j] = "0";
                }
            }

            Console.WriteLine($"{words[i]} : {count}");
        }
    }
}
