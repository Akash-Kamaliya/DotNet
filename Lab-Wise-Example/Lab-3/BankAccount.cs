using System;

class BankAccount
{
    int accountNumber;
    string holderName;
    double balance;

    public BankAccount(int acc, string name, double bal)
    {
        accountNumber = acc;
        holderName = name;
        balance = bal;
    }

    public void Deposit(double amount)
    {
        balance += amount;
        Console.WriteLine("Deposited: " + amount);
    }

    public void Withdraw(double amount)
    {
        if (amount > balance)
            throw new AccountException("Insufficient Balance");

        balance -= amount;
        Console.WriteLine("Withdrawn: " + amount);
    }

    public void Display()
    {
        Console.WriteLine($"Account: {accountNumber}, Name: {holderName}, Balance: {balance}");
    }
}
