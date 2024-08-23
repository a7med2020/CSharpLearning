using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Threads
{
    public class UsingAsyncAndAwaitWithTasks
    {
        public static async Task Execute()
        {
            // Call an asynchronous method
            int result = await CalculateSumAsync(10);

            Console.WriteLine($"The sum is: {result}");
        }

        static async Task<int> CalculateSumAsync(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
                await Task.Delay(500); // Simulate work with an asynchronous delay
            }
            return sum;
        }
    }
}
