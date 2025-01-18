using LockSync;

var tasks = new List<Task>();
var bankAccount = new BankAccount();

for (var i = 0; i < 10; i++)
{
    tasks.Add(Task.Run(() =>
    {
        for (var j = 0; j < 100; j++)
            bankAccount.Deposit(100);
    }));
    
    tasks.Add(Task.Run(() =>
    {
        for (var k = 0; k < 100; k++)
            bankAccount.Withdraw(100);
    }));
}

await Task.WhenAll(tasks.ToArray());

Console.WriteLine($"Final balance is {bankAccount.Balance}");

