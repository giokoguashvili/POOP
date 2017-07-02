public interface IAccount
{
    string Balance();
    IAccount Deposit(decimal amount);
    IAccount Withdraw(decimal amount);
    IAccount Verify();
    IAccount Froze();
    IAccount Close();
}