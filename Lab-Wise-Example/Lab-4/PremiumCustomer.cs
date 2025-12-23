using System;

class PremiumCustomer : Customer
{
    public PremiumCustomer(double amt) : base(amt) { }

    public override double CalculateBill()
    {
        return amount * 0.90;
    }
}
