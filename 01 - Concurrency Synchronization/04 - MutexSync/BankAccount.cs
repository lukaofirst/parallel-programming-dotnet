namespace MutexSync;

public class BankAccount
{
    public int Balance { get; private set; }

    public BankAccount(int balance)
    {
        Balance = balance;
    }

    public void Deposit(int amount)
    {
        Balance += amount;
    }

    public void Withdraw(int amount)
    {
        Balance -= amount;
    }

    public void Transfer(BankAccount where, int amount)
    {
        where.Balance += amount;
        Balance -= amount;
    }
}