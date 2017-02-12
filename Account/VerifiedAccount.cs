using System;

internal class VerifiedAccount : IAccount
{
    private IAccount account;

    public VerifiedAccount(IAccount account)
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
        return account.Froze();
    }

    public IAccount Verify()
    {
        return account.Verify();
    }

    public IAccount Withdraw(decimal amount)
    {
        return account.Withdraw(amount);
    }
}