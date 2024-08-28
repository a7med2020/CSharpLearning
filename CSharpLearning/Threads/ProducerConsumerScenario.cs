using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Threads
{
    public class ProducerConsumerScenario
    {
        public static void Execute()
        {
            var blockingCollection = new BlockingCollection<int>(boundedCapacity: 5);

            // Producer task
            Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    blockingCollection.Add(i);
                    Console.WriteLine($"Added {i}");
                }
                blockingCollection.CompleteAdding();
            });

            // Consumer task
            Task.Run(() =>
            {
                foreach (var item in blockingCollection.GetConsumingEnumerable())
                {
                    Console.WriteLine($"Consumed {item}");
                }
            });
        }
    }
}
