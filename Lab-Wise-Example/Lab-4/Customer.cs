using System;

class Customer
{
    protected double amount;

    public Customer(double amt)
    {
        amount = amt;
    }

    public virtual double CalculateBill()
    {
        return amount;
    }
}
