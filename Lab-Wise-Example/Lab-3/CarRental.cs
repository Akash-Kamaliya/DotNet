using System;

class CarRental
{
    string model;
    double rate;
    int days;

    public CarRental(string m, double r, int d)
    {
        if (d <= 0)
            throw new Exception("Invalid Days");

        model = m;
        rate = r;
        days = d;
    }

    public double CalculateRent()
    {
        return rate * days;
    }
}
