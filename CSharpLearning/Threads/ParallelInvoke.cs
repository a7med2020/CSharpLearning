using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Threads
{
    /// <summary>
    /// Parallel.Invoke is a method provided by the System.Threading.Tasks.Parallel class in .NET 
    /// Explanation:
    ///Parallel.Invoke: Runs all the actions concurrently and waits for all of them to finish.It's straightforward for simple scenarios.
    ///Task: Provides more control, allowing you to manage, chain, and handle tasks individually.This approach is more flexible and suitable for complex workflows.
    ///When to Use Each:
    ///Parallel.Invoke: Use it when you have a fixed set of independent actions that need to run in parallel, and you don't need to manage their execution individually.
    ///Task: Use it when you need more control over the execution, such as chaining tasks, returning values, handling exceptions individually, or when you have complex asynchronous workflows.
    /// </summary>
    class ParallelInvoke
    {
        public static void Execute()
        {
            // Using Parallel.Invoke to run multiple actions concurrently
            Parallel.Invoke(
                () => PrintNumbers(1),
                () => PrintNumbers(2),
                () => PrintNumbers(3)
            );

            Console.WriteLine("All tasks are done.");
        }

        static void PrintNumbers(int taskNumber)
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Task {taskNumber}: {i}");
                Task.Delay(500).Wait(); // Simulate work
            }
        }
    }
}
