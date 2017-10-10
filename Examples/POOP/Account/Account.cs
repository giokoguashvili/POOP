using System;

public class Account : IAccount
{
    private decimal _balence;
    public Account(decimal balance)
    {
        this._balence = balance;
    }

    public string Balance()
    {
        return $"Balance is ${_balence}";
    }

    public IAccount Deposit(decimal amount)
    {
        return new Account(this._balence + amount);
    }

    public IAccount Withdraw(decimal amount)
    {
        return new Account(this._balence - amount);
    }

    public IAccount Froze()
    {
        return new FrozenAccount(this);
    }

    public IAccount Verify()
    {
        return new VerifiedAccount(this);
    }

    public IAccount Close()
    {
        return new ClosedAccount(this);
    }
}