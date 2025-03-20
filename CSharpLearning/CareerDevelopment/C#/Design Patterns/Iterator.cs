using System;
using System.Collections;

// Aggregate interface
interface IAggregate
{
    IIterator GetIterator();
}

// Iterator interface
interface IIterator
{
    bool HasNext();
    object Next();
}

// Concrete aggregate
class ConcreteAggregate : IAggregate
{
    private ArrayList _items = new ArrayList();

    public void AddItem(object item)
    {
        _items.Add(item);
    }

    public IIterator GetIterator()
    {
        return new ConcreteIterator(this);
    }

    public int Count
    {
        get { return _items.Count; }
    }

    public object this[int index]
    {
        get { return _items[index]; }
    }
}

// Concrete iterator
class ConcreteIterator : IIterator
{
    private ConcreteAggregate _aggregate;
    private int _index = 0;

    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        _aggregate = aggregate;
    }

    public bool HasNext()
    {
        return _index < _aggregate.Count;
    }

    public object Next()
    {
        if (!HasNext())
        {
            throw new InvalidOperationException("No more elements to iterate");
        }

        return _aggregate[_index++];
    }
}

// Client code
class Program
{
    static void Main()
    {
        var aggregate = new ConcreteAggregate();
        aggregate.AddItem("Item 1");
        aggregate.AddItem("Item 2");
        aggregate.AddItem("Item 3");

        var iterator = aggregate.GetIterator();
        while (iterator.HasNext())
        {
            var item = iterator.Next();
            Console.WriteLine(item);
        }
    }
}