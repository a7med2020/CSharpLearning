using System;
using System.Collections.Generic;

// Subject interface
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Concrete subject
public class Subject : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private int _state;

    public int State
    {
        get => _state;
        set
        {
            _state = value;
            Notify();
        }
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }
}

// Observer interface
public interface IObserver
{
    void Update();
}

// Concrete observer
public class ConcreteObserver : IObserver
{
    private readonly Subject _subject;

    public ConcreteObserver(Subject subject)
    {
        _subject = subject;
        _subject.Attach(this);
    }

    public void Update()
    {
        Console.WriteLine($"Observer: Subject's state has changed to {_subject.State}");
    }
}

// Usage
public class Program
{
    public static void Main()
    {
        Subject subject = new Subject();
        ConcreteObserver observer1 = new ConcreteObserver(subject);
        ConcreteObserver observer2 = new ConcreteObserver(subject);

        subject.State = 1;
        subject.State = 2;

        // Output:
        // Observer: Subject's state has changed to 1
        // Observer: Subject's state has changed to 1
        // Observer: Subject's state has changed to 2
        // Observer: Subject's state has changed to 2
    }
}
