// See https://aka.ms/new-console-template for more information

using MutexSync;

await LocalMutex();
//GlobalMutex();

static async Task LocalMutex()
{
    var tasks = new List<Task>();
    var bankAccount = new BankAccount(0);
    var bankAccount2 = new BankAccount(0);
    
    // Mutex == MUTual EXclusion
    var mutex = new Mutex();
    var mutex2 = new Mutex();

    for (var i = 0; i < 10; i++)
    {
        tasks.Add(Task.Run(() =>
        {
            for (var j = 0; j < 1000; j++)
            {
                var haveLock = mutex.WaitOne();

                try
                {
                    bankAccount.Deposit(1);
                }
                finally
                {
                    if (haveLock) mutex.ReleaseMutex();
                }
            }
        }));
        
        tasks.Add(Task.Run(() =>
        {
            for (var k = 0; k < 1000; k++)
            {
                var haveLock = mutex2.WaitOne();

                try
                {
                    bankAccount2.Deposit(1);
                }
                finally
                {
                    if (haveLock) mutex2.ReleaseMutex();
                }
            }
        }));
        
        tasks.Add(Task.Run(() =>
        {
            for (var w = 0; w < 1000; w++)
            {
                var haveLock = WaitHandle.WaitAll([mutex, mutex2]);

                try
                {
                    bankAccount.Transfer(bankAccount2, 1);
                }
                finally
                {
                    if (haveLock)
                    {
                        mutex.ReleaseMutex();
                        mutex2.ReleaseMutex();
                    }
                }
            }
        }));
    }

    await Task.WhenAll(tasks.ToArray());
    
    Console.WriteLine($"Final balance is: ba={bankAccount.Balance}, ba2={bankAccount2.Balance}.");
}

static void GlobalMutex()
{
    const string appName = "MyApp";
    Mutex mutex;
    try
    {
        mutex = Mutex.OpenExisting(appName);
        Console.WriteLine($"Sorry, {appName} is already running.");
        return;
    }
    catch (WaitHandleCannotBeOpenedException e)
    {
        Console.WriteLine("We can run the program just fine.");
        // first arg = whether to give current thread initial ownership
        mutex = new Mutex(false, appName);
    }

    Console.ReadKey();
}
