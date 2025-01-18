<div align="center">
  <h1>Parallel Programming in .NET</h1>
</div>

This repository provides examples and exercises on parallel programming in .NET, covering synchronization mechanisms, concurrent collections, task coordination, parallel loops, and Parallel LINQ.

-   <b>Main Topics Learned</b>

    -   **Concurrency != Parallelism**:

        -   **Concurrency**: It's the capacity to handle multiple tasks at once

        -   **Parallelism**: It's the capacity to execute multiple tasks at once

    -   **Concurrency Synchronization**: Covers different synchronization mechanisms to manage concurrent access to shared resources

    -   **Concurrent Collections**: Covers the usage of thread-safe collections

    -   **Task Coordination**: Covers different techniques to coordinate tasks

    -   **Parallel Loops**: Covers the use of parallel loops to perform parallel operations on collections

    -   **Parallel LINQ**: Covers the usage of PLINQ (Parallel LINQ) to perform parallel operations on collections

-   **Topics in Details**

    -   **Concurrency Synchronization**

        -   **LockSync**: Demonstrates the use of `lock` statement to synchronize access to a shared resource.

        -   **Interlocked**: Shows how to use `Interlocked` class for atomic operations on shared variables.

        -   **SpinLockSync**: Explains the use of `SpinLock` for low-level synchronization.

        -   **MutexSync**: Demonstrates the use of `Mutex` for inter-process synchronization.

        -   **ReaderWriterLockSync**: Shows how to use `ReaderWriterLockSlim` to allow multiple readers or exclusive access to a resource.

    -   **Concurrent Collections**

        -   **ListAndConcurrentBag**: Compares the use of `List` with locks and `ConcurrentBag` for thread-safe operations.

        -   **DictionaryAndConcurrentDictionary**: Compares the use of `Dictionary` with locks and `ConcurrentDictionary` for thread-safe operations.

        -   **QueueAndConcurrentQueue**: Compares the use of `Queue` with locks and `ConcurrentQueue` for thread-safe operations.

        -   **StackAndConcurrentStack**: Compares the use of `Stack` with locks and `ConcurrentStack` for thread-safe operations.

    -   **Task Coordination**

        -   **Task Continuation**: Demonstrates how to chain tasks using continuations.

        -   **Child Tasks**: Shows how to create and manage child tasks.

        -   **Barrier**: Explains the use of `Barrier` to synchronize multiple tasks at a specific point.

        -   **Countdown Event**: Demonstrates the use of `CountdownEvent` to wait for multiple tasks to signal completion.

        -   **Reset Event**: Shows how to use `ManualResetEventSlim` for signaling between tasks.

        -   **Semaphore**: Demonstrates the use of `SemaphoreSlim` to limit the number of concurrent tasks.

    -   **Parallel Loops**

        -   **Parallel Invoke**: Demonstrates the use of `Parallel.Invoke` to run multiple actions in parallel.

        -   **ForEach and ForEachAsync**: Shows how to use `Parallel.ForEach` and `Parallel.ForEachAsync` for parallel iteration over collections.

        -   **For and ForAsync**: Demonstrates the use of `Parallel.For` and `Parallel.ForAsync` for parallel iteration with indices.

        -   **Thread Local Storage**: Explains the use of thread-local storage in parallel loops.

        -   **Partitioning**: Shows how to partition data for parallel processing.

        -   **Handling Exceptions**: Demonstrates how to handle exceptions in parallel loops.

    -   **Parallel LINQ**

        -   **AsParallel**: Demonstrates the use of `AsParallel` to enable parallel processing of LINQ queries.

        -   **ParallelQuery**: Shows how to create and use `ParallelQuery` for parallel LINQ operations.

        -   **Handling Cancellations and Exceptions**: Explains how to handle cancellations and exceptions in PLINQ queries.

        -   **Merge Options**: Demonstrates the use of merge options to control the buffering behavior of PLINQ queries.

        -   **Custom Aggregations**: Shows how to perform custom aggregations in PLINQ queries.
