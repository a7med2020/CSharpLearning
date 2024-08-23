using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Threads
{
    public class ReturningValueFromTask
    {
        static void Execute(string[] args)
        {
            // Create and start a Task that returns a result
            Task<int> task = Task.Run(() => CalculateSum(10));

            // Continue with the main thread
            Console.WriteLine("Main thread continues to run...");

            // Wait for the task to complete and get the result
            int result = task.Result;

            Console.WriteLine($"The sum is: {result}");
        }

        static int CalculateSum(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
                Task.Delay(500).Wait(); // Simulate work with a delay
            }
            return sum;
        }
    }
}
