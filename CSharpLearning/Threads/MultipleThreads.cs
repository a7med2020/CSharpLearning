using System;
using System.Threading;
namespace CSharpLearning.Threads
{
    public class MultipleThreads
    {
        static void Execute()
        {
            Thread thread1 = new Thread(() => PrintMessage("Thread 1", 5));
            Thread thread2 = new Thread(() => PrintMessage("Thread 2", 3));

            thread1.Start();
            thread2.Start();

            thread1.Join(); // Wait for thread1 to finish
            thread2.Join(); // Wait for thread2 to finish

            Console.WriteLine("Both threads have finished.");
        }

        static void PrintMessage(string threadName, int count)
        {
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine($"{threadName} - Message {i}");
                Thread.Sleep(1000);
            }
        }
    }
}
