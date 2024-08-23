using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Threads
{
    public class BasicTaskExample
    {
        public static void Execute()
        {
            // Create and start a new Task
            Task task = Task.Run(() => PrintNumbers());

            // Continue with the main thread
            Console.WriteLine("Main thread continues to run...");

            // Wait for the task to complete
            task.Wait();

            Console.WriteLine("Task has completed.");
        }

        static void PrintNumbers()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
                Task.Delay(3000).Wait(); // Simulate work with a delay
            }
        }
    }
}
