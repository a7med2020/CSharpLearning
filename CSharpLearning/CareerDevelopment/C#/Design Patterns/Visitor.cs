using System;

// Element interface that defines the accept method
public interface IElement
{
    void Accept(IVisitor visitor);
}

// Concrete element class
public class ConcreteElementA : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementA(this);
    }

    public void OperationA()
    {
        Console.WriteLine("Operation A");
    }
}

// Concrete element class
public class ConcreteElementB : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementB(this);
    }

    public void OperationB()
    {
        Console.WriteLine("Operation B");
    }
}

// Visitor interface
public interface IVisitor
{
    void VisitConcreteElementA(ConcreteElementA element);
    void VisitConcreteElementB(ConcreteElementB element);
}

// Concrete visitor class
public class ConcreteVisitor : IVisitor
{
    public void VisitConcreteElementA(ConcreteElementA element)
    {
        element.OperationA();
    }

    public void VisitConcreteElementB(ConcreteElementB element)
    {
        element.OperationB();
    }
}

// Client code
public class Client
{
    public static void Main()
    {
        var elements = new IElement[] { new ConcreteElementA(), new ConcreteElementB() };
        var visitor = new ConcreteVisitor();

        foreach (var element in elements)
        {
            element.Accept(visitor);
        }
    }
}
