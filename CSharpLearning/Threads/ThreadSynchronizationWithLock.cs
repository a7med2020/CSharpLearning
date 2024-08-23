using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSharpLearning.Threads
{
    public class ThreadSynchronizationWithLock
    {
        private static readonly object lockObject = new object();
        private static int counter = 0;

        public static void Execute()
        {
            Thread thread1 = new Thread(IncrementCounter);
            Thread thread2 = new Thread(IncrementCounter);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Final counter value: {counter}");
        }

        static void IncrementCounter()
        {
            for (int i = 0; i < 200; i++)
            {
                lock (lockObject)
                {
                    counter++;
                }
            }
        }
    }
}
