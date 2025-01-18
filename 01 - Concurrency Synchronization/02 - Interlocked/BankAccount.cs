namespace InterlockedSync;

public class BankAccount
{
    private int _balance;

    public int Balance => _balance;

    public void Deposit(int amount)
    {
        Interlocked.Add(ref _balance, amount);
    }

    public void Withdraw(int amount)
    {
        Interlocked.Add(ref _balance, -amount);
    }
}