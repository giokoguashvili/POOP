using System;

internal class FrozenAccount : IAccount
{
    private IAccount account;

    public FrozenAccount(IAccount account)
    {
        this.account = account;
    }

    public string Balance()
    {
        return account.Balance();
    }

    public IAccount Close()
    {
        return account.Close();
    }

    public IAccount Deposit(decimal amount)
    {
        return account.Deposit(amount);
    }

    public IAccount Froze()
    {
        return this;
    }

    public IAccount Verify()
    {
        return this;
    }

    public IAccount Withdraw(decimal amount)
    {
        return this;
    }
}