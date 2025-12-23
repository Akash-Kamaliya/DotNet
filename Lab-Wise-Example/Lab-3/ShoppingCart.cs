using System;

class ShoppingCart
{
    string item;
    double price;
    int quantity;

    public ShoppingCart(string i, double p, int q)
    {
        if (q <= 0)
            throw new Exception("Invalid Quantity");

        item = i;
        price = p;
        quantity = q;
    }

    public double Total()
    {
        return price * quantity;
    }
}
