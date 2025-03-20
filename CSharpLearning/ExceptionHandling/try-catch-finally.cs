using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearning.ExceptionHandling
{
    class try_catch_finally
    {
        void ExceptionFun()
        {
            try
            {
                // Code to try goes here.
            }
            catch (/*SomeSpecificException*/Exception ex)
            {
                // Code to handle the exception goes here.
                // Only catch exceptions that you know how to handle.
                // Never catch base class System.Exception without
                // rethrowing it at the end of the catch block.
            }


            try
            {
                // Code to try goes here.
            }
            finally
            {
                // Code to execute after the try block goes here.
            }


            try
            {
                // Code to try goes here.
            }
            catch (/*SomeSpecificException*/Exception ex)
            {
                // Code to handle the exception goes here.
            }
            finally
            {
                // Code to execute after the try (and possibly catch) blocks
                // goes here.
            }
        }
    }
}
