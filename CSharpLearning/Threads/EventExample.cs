using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSharpLearning.Threads
{
    /// <summary>
    /// Publisher-Subscriber Model:
    ///Publisher: The class that contains the event is called the "publisher." It publishes the event.
    ///Subscriber: The classes that register or subscribe to the event are called "subscribers." They handle the event when it is raised.
    /// </summary>
    // Step 1: Define a delegate that represents the event's method signature
    public delegate void Notify();  // No return type, no parameters

    // Step 2: Declare a class that contains the event
    public class ProcessBusinessLogic
    {
        // Step 3: Declare the event using the delegate
        public event Notify ProcessCompleted;

        // Method to start the process and raise the event
        public void StartProcess()
        {
            Console.WriteLine("Process started.");

            // Simulate some process
            Thread.Sleep(2000);

            // Step 4: Raise the event to notify subscribers
            OnProcessCompleted();
        }

        // Protected virtual method to raise the event
        protected virtual void OnProcessCompleted()
        {
            // Raise the event if there are subscribers
            ProcessCompleted?.Invoke();
        }
    }

    // A class that subscribes to the event
    public class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the publisher class
            ProcessBusinessLogic process = new ProcessBusinessLogic();

            // Subscribe to the event using a method
            process.ProcessCompleted += Process_ProcessCompleted;

            // Start the process
            process.StartProcess();

            Console.ReadKey();
        }

        // Event handler method
        private static void Process_ProcessCompleted()
        {
            Console.WriteLine("Process completed!");
        }
    }
    class EventExample
    {
    }
}
