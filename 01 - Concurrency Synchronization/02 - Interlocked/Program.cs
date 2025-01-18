using InterlockedSync;

var tasks = new List<Task>();
var bankAccount = new BankAccount();

for (var i = 0; i < 10; i++)
{
    tasks.Add(Task.Factory.StartNew(() =>
    {
        for (var j = 0; j < 1000; j++)
            bankAccount.Deposit(100);
    }));
    tasks.Add(Task.Factory.StartNew(() =>
    {
        for (var k = 0; k < 1000; k++)
            bankAccount.Withdraw(100);
    }));
}

await Task.WhenAll(tasks.ToArray());

Console.WriteLine($"Final balance is {bankAccount.Balance}");