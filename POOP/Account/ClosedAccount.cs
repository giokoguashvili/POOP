internal class ClosedAccount : IAccount
{
    private IAccount account;

    public ClosedAccount(IAccount account)
    {
        this.account = account;
    }

    public string Balance()
    {
        return account.Balance();
    }

    public IAccount Close()
    {
        return this;
    }

    public IAccount Deposit(decimal amount)
    {
        return this;
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