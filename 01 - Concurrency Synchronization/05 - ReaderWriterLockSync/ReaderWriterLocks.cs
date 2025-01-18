namespace ReaderWriterLockSync;

public static class ReaderWriterLocks
{
    // recursion is not recommended and can lead to deadlocks
    private static readonly ReaderWriterLockSlim _padlock = new(LockRecursionPolicy.SupportsRecursion);

    public static async Task Run()
    {
        var x = 0;

        var tasks = new List<Task>();
        for (var i = 0; i < 10; i++)
        {
            tasks.Add(Task.Factory.StartNew(() =>
            {
                //padlock.EnterReadLock();
                //padlock.EnterReadLock();
                _padlock.EnterUpgradeableReadLock();

                if (i % 2 == 0)
                {
                    _padlock.EnterWriteLock();
                    x++;
                    _padlock.ExitWriteLock();
                }

                // can now read
                Console.WriteLine($"Entered read lock, x = {x}, pausing for 5sec");
                Thread.Sleep(5000);

                //padlock.ExitReadLock();
                //padlock.ExitReadLock();
                _padlock.ExitUpgradeableReadLock();

                Console.WriteLine($"Exited read lock, x = {x}.");
            }));
        }

        try
        {
            await Task.WhenAll(tasks.ToArray());
        }
        catch (AggregateException ae)
        {
            ae.Handle(e =>
            {
                Console.WriteLine(e);
                return true;
            });
        }

        var random = new Random();

        while (true)
        {
            Console.ReadKey();
            _padlock.EnterWriteLock();
            Console.WriteLine("Write lock acquired");
            var newValue = random.Next(10);
            x = newValue;
            Console.WriteLine($"Set x = {x}");
            _padlock.ExitWriteLock();
            Console.WriteLine("Write lock released");
        }
    }
}