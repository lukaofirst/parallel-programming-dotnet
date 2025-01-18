namespace LockSync;

public class BankAccount
{
    private readonly Lock _lock = new();
    public int Balance { get; private set; }

    public void Deposit(int amount)
    {
        lock (_lock)
        {
            Balance += amount;
        }
    } 
    
    public void Withdraw(int amount)
    {
        lock (_lock)
        {
            Balance -= amount;
        }
    }
}