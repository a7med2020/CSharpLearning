using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpLearning.Threads
{
    class ParallelLoop
    {
        public static void Execute()
        {
            //ForExample1();
            //ForExample2();
            ForEachExample1();
        }

        static void ForExample1()
        {
            Parallel.For(0, 100, i =>
            {
                Console.WriteLine($"Processing number {i} on thread {Task.CurrentId}");
                // Simulate work
                Task.Delay(1000).Wait();
            });
        }

        static void ForExample2()
        {
            var rnd = new Random();
            int breakIndex = rnd.Next(1, 11);

            Console.WriteLine($"Will call Break at iteration {breakIndex}\n");

            var result = Parallel.For(1, 101, (i, state) =>
            {
                Console.WriteLine($"Beginning iteration {i}");
                int delay;
                lock (rnd)
                    delay = rnd.Next(1, 1001);
                Thread.Sleep(delay);

                if (state.ShouldExitCurrentIteration)
                {
                    if (state.LowestBreakIteration < i)
                        return;
                }

                if (i == breakIndex)
                {
                    Console.WriteLine($"Break in iteration {i}");
                    state.Stop();
                }

                Console.WriteLine($"Completed iteration {i}");
            });

            if (result.LowestBreakIteration.HasValue)
                Console.WriteLine($"\nLowest Break Iteration: {result.LowestBreakIteration}");
            else
                Console.WriteLine($"\nNo lowest break iteration.");
        }

        static void ForEachExample1()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            Parallel.ForEach(numbers, number =>
            {
                Console.WriteLine($"Processing number {number} on thread {Task.CurrentId}");
                // Simulate work
                Task.Delay(100).Wait();
            });
        }


        //MaxDegreeOfParallelism //Gets or sets the maximum number of concurrent tasks enabled by this ParallelOptions instance.
    }
}

