using System;

abstract class Payment
{
    public abstract void MakePayment(double amount);
}

class CreditCardPayment : Payment
{
    public override void MakePayment(double amount)
    {
        if (amount < 100)
            throw new Exception("Minimum payment is 100");

        Console.WriteLine("Paid via Credit Card: " + amount);
    }
}

class UPIPayment : Payment
{
    public override void MakePayment(double amount)
    {
        if (amount < 100)
            throw new Exception("Minimum payment is 100");

        Console.WriteLine("Paid via UPI: " + amount);
    }
}
