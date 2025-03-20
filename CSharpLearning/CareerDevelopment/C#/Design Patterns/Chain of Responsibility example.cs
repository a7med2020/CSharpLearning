using System;

// Handler interface
interface IHandler
{
    void HandleRequest(int request);
}

// Concrete handler
class ConcreteHandler1 : IHandler
{
    private IHandler _nextHandler;

    public void SetNext(IHandler handler)
    {
        _nextHandler = handler;
    }

    public void HandleRequest(int request)
    {
        if (request < 10)
        {
            Console.WriteLine($"{request} handled by ConcreteHandler1");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(request);
        }
    }
}

// Another concrete handler
class ConcreteHandler2 : IHandler
{
    public void HandleRequest(int request)
    {
        Console.WriteLine($"{request} handled by ConcreteHandler2");
    }
}

// Client code
class Program
{
    static void Main()
    {
        // Creating the chain of handlers
        var handler1 = new ConcreteHandler1();
        var handler2 = new ConcreteHandler2();
        handler1.SetNext(handler2);

        // Sending requests
        int[] requests = { 2, 5, 14, 22 };
        foreach (int request in requests)
        {
            handler1.HandleRequest(request);
        }
    }
}
