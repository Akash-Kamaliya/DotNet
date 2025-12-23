using System;

class FlightTicket
{
    public FlightTicket(string name, string flight, double price)
    {
        if (price < 500)
            throw new Exception("Invalid Ticket Price");

        Console.WriteLine($"Passenger: {name}, Flight: {flight}, Price: {price}");
    }
}
