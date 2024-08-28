﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearning.Statements.YieldStatement
{
    class YieldStatement
    {
        public void Execute()
        {
            var numbers = ProduceEvenNumbers(5);
            Console.WriteLine("Caller: about to iterate.");
            foreach (int i in numbers)
            {
                Console.WriteLine($"Caller: {i}");
            }

            IEnumerable<int> ProduceEvenNumbers(int upto)
            {
                Console.WriteLine("Iterator: start.");
                for (int i = 0; i <= upto; i += 2)
                {
                    Console.WriteLine($"Iterator: about to yield {i}");
                    yield return i;
                    Console.WriteLine($"Iterator: yielded {i}");
                }
                Console.WriteLine("Iterator: end.");
            }
            // Output:
            // Caller: about to iterate.
            // Iterator: start.
            // Iterator: about to yield 0
            // Caller: 0
            // Iterator: yielded 0
            // Iterator: about to yield 2
            // Caller: 2
            // Iterator: yielded 2
            // Iterator: about to yield 4
            // Caller: 4
            // Iterator: yielded 4
            // Iterator: end.
        }
    }
}
