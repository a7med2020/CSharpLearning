using System;
using System.Collections.Generic;

// Mediator interface
public interface IChatRoom
{
    void SendMessage(User user, string message);
}

// Concrete mediator
public class ChatRoom : IChatRoom
{
    private readonly List<User> _users = new List<User>();

    public void RegisterUser(User user)
    {
        _users.Add(user);
    }

    public void SendMessage(User user, string message)
    {
        foreach (var u in _users)
        {
            if (u != user) // Exclude the sender
            {
                u.ReceiveMessage(user, message);
            }
        }
    }
}

// Colleague interface
public abstract class User
{
    protected readonly IChatRoom _chatRoom;
    protected readonly string _name;

    public User(IChatRoom chatRoom, string name)
    {
        _chatRoom = chatRoom;
        _name = name;
    }

    public abstract void SendMessage(string message);

    public virtual void ReceiveMessage(User sender, string message)
    {
        Console.WriteLine($"{_name} received a message from {sender._name}: {message}");
    }
}

// Concrete colleague
public class BasicUser : User
{
    public BasicUser(IChatRoom chatRoom, string name) : base(chatRoom, name) { }

    public override void SendMessage(string message)
    {
        _chatRoom.SendMessage(this, message);
    }
}

// Concrete colleague
public class PremiumUser : User
{
    public PremiumUser(IChatRoom chatRoom, string name) : base(chatRoom, name) { }

    public override void SendMessage(string message)
    {
        _chatRoom.SendMessage(this, $"[VIP] {message}");
    }
}

// Usage
public class Program
{
    public static void Main()
    {
        IChatRoom chatRoom = new ChatRoom();
        User user1 = new BasicUser(chatRoom, "User1");
        User user2 = new BasicUser(chatRoom, "User2");
        User user3 = new PremiumUser(chatRoom, "User3");

        chatRoom.RegisterUser(user1);
        chatRoom.RegisterUser(user2);
        chatRoom.RegisterUser(user3);

        user1.SendMessage("Hello everyone!");
        user3.SendMessage("This is a premium message!");

        // Output:
        // User2 received a message from User1: Hello everyone!
        // User1 received a message from User3: [VIP] This is a premium message!
        // User2 received a message from User3: [VIP] This is a premium message!
    }
}