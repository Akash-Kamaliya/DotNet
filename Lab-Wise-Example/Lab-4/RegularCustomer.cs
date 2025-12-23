using System;

class RegularCustomer : Customer
{
    public RegularCustomer(double amt) : base(amt) { }

    public override double CalculateBill()
    {
        return amount * 0.95;
    }
}
