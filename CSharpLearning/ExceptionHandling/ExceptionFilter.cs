using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearning.ExceptionHandling
{
    public class ExceptionFilter
    {

        //You can also specify exception filters to add a boolean expression to a catch clause.
        //Exception filters indicate that a specific catch clause matches only when that condition is true.
        //In the following example, both catch clauses use the same exception class, but an extra condition is checked to create a different error message:
        int GetInt(int[] array, int index)
        {
            try
            {
                return array[index];
            }
            catch (IndexOutOfRangeException e) when (index < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Parameter index cannot be negative.", e);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException(
                    "Parameter index cannot be greater than the array size.", e);
            }
        }

        //An exception filter that always returns false can be used to examine all exceptions but not process them. A typical use is to log exceptions:

        
            public static void Execute()
            {
                try
                {
                    string? s = null;
                    Console.WriteLine(s.Length);
                }
                catch (Exception e) when (LogException(e))
                {
                }
                Console.WriteLine("Exception must have been handled");
            }

            private static bool LogException(Exception e)
            {
                Console.WriteLine($"\tIn the log routine. Caught {e.GetType()}");
                Console.WriteLine($"\tMessage: {e.Message}");
                return false;
            }
        

    }
}
