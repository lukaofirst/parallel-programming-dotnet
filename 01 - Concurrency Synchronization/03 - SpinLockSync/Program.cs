using SpinLockSync;

var tasks = new List<Task>();
var bankAccount = new BankAccount();

var spinLock = new SpinLock();

for (var i = 0; i < 10; i++)
{
    tasks.Add(Task.Run(() =>
    {
        var lockTaken = false;
        try
        {
            spinLock.Enter(ref lockTaken);
            bankAccount.Deposit(100);
        }
        finally
        {
            if (lockTaken) spinLock.Exit();
        }
    }));
    
    tasks.Add(Task.Run(() =>
    {
        var lockTaken = false;
        try
        {
            spinLock.Enter(ref lockTaken);
            bankAccount.Withdraw(100);
        }
        finally
        {
            if (lockTaken) spinLock.Exit();
        }
    }));
}

await Task.WhenAll(tasks.ToArray());

Console.WriteLine($"Final balance is {bankAccount.Balance}");