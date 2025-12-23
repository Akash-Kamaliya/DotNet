using System;

class BankTransaction
{
    private double balance = 10000;

    public void Transfer(double amount)
    {
        balance -= amount;
        Console.WriteLine("Transferred: " + amount);
    }

    public void Transfer(double amount, string message)
    {
        balance -= amount;
        Console.WriteLine($"Transferred: {amount}, Note: {message}");
    }
}
