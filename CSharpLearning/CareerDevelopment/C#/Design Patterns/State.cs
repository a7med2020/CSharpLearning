using System;

// Context
public class VendingMachine
{
    private VendingMachineState _state;

    public VendingMachine()
    {
        _state = new ReadyState();
    }

    public void SetState(VendingMachineState state)
    {
        _state = state;
    }

    public void InsertCoin()
    {
        _state.InsertCoin(this);
    }

    public void PressButton()
    {
        _state.PressButton(this);
    }

    public void DispenseItem()
    {
        Console.WriteLine("Item dispensed. Enjoy your drink!");
    }
}

// State
public abstract class VendingMachineState
{
    public abstract void InsertCoin(VendingMachine vendingMachine);
    public abstract void PressButton(VendingMachine vendingMachine);
}

// Concrete States
public class ReadyState : VendingMachineState
{
    public override void InsertCoin(VendingMachine vendingMachine)
    {
        Console.WriteLine("Coin inserted. Please select a drink.");
        vendingMachine.SetState(new CoinInsertedState());
    }

    public override void PressButton(VendingMachine vendingMachine)
    {
        Console.WriteLine("Please insert a coin first.");
    }
}

public class CoinInsertedState : VendingMachineState
{
    public override void InsertCoin(VendingMachine vendingMachine)
    {
        Console.WriteLine("Coin already inserted.");
    }

    public override void PressButton(VendingMachine vendingMachine)
    {
        vendingMachine.DispenseItem();
        vendingMachine.SetState(new ReadyState());
    }
}

// Usage
public class Program
{
    public static void Main()
    {
        VendingMachine vendingMachine = new VendingMachine();

        vendingMachine.PressButton();  // Output: Please insert a coin first.
        vendingMachine.InsertCoin();   // Output: Coin inserted. Please select a drink.
        vendingMachine.PressButton();  // Output: Item dispensed. Enjoy your drink.
    }
}