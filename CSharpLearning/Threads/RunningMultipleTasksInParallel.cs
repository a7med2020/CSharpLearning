using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Threads
{
    public class RunningMultipleTasksInParallel
    {
        public static void Execute()
        {
            // Start multiple tasks
            Task task1 = Task.Run(() => PrintMessage("Task 1", 3));
            Task task2 = Task.Run(() => PrintMessage("Task 2", 2));
            Task task3 = Task.Run(() => PrintMessage("Task 3", 4));

            // Wait for all tasks to complete
            Task.WaitAll(task1, task2, task3);

            Console.WriteLine("All tasks have completed.");
        }

        static void PrintMessage(string taskName, int count)
        {
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine($"{taskName} - Message {i}");
                Task.Delay(1000).Wait();
            }
        }
    }
}
