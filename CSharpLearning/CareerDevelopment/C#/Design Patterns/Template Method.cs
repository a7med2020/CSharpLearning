using System;

// Abstract class defining the template method
public abstract class AbstractClass
{
    // The template method defines the algorithm structure
    public void TemplateMethod()
    {
        Step1();
        Step2();
        Step3();
    }

    // Abstract methods to be implemented by subclasses
    protected abstract void Step1();
    protected abstract void Step2();

    // Optional hook method that can be overridden by subclasses
    protected virtual void Step3()
    {
        Console.WriteLine("Default implementation of Step3");
    }
}

// Concrete subclass implementing the template method
public class ConcreteClass : AbstractClass
{
    protected override void Step1()
    {
        Console.WriteLine("Step 1");
    }

    protected override void Step2()
    {
        Console.WriteLine("Step 2");
    }

    protected override void Step3()
    {
        Console.WriteLine("Custom implementation of Step3");
    }
}

// Usage
public class Program
{
    public static void Main()
    {
        AbstractClass obj = new ConcreteClass();
        obj.TemplateMethod();
    }
}
