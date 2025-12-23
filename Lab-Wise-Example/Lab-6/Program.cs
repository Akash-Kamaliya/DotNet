using System;
namespace Lab_6{
    class Program
    {
        static void Main()
        {
            new RecentTasks().Run();
            new CustomerQueue().Run();
            new VowelConsonantCount().Count();
            new StringPalindrome().Check();
            new WordFrequency().Count();
            new ShoppingList().Run();
            new WordCountDictionary().Count();
            new UniqueEmails().Run();
            new LibraryBorrowers().Run();
            new HospitalQueue().Run();
        }
    }
}