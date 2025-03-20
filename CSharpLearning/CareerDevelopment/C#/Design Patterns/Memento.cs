using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyCourse_DesignPatternsInCSharpAndDotNET.BehavioralDesignPatterns._18Memento.More.TextEditor
{
    class TextEditor
    {
        private string content;

        public string Content
        {
            get => content;
            set
            {
                content = value;
                Console.WriteLine("Editor content updated: " + content);
            }
        }

        public EditorMemento Save()
        {
            return new EditorMemento(content);
        }

        public void Restore(EditorMemento memento)
        {
            content = memento.Content;
            Console.WriteLine("Editor content restored: " + content);
        }
    }

    // Memento: Stores the internal state of the Originator
    class EditorMemento
    {
        public string Content { get; private set; }

        public EditorMemento(string content)
        {
            Content = content;
        }
    }

    // Caretaker: Manages and keeps track of multiple mementos
    class History
    {
        private Stack<EditorMemento> mementos = new Stack<EditorMemento>();

        public void Push(EditorMemento memento)
        {
            mementos.Push(memento);
        }

        public EditorMemento Pop()
        {
            return mementos.Pop();
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            TextEditor editor = new TextEditor();
            History history = new History();

            editor.Content = "Hello, World!";
            history.Push(editor.Save());

            editor.Content = "Hello, Design Patterns!";
            history.Push(editor.Save());

            editor.Content = "Hello, Memento Pattern!";
            history.Push(editor.Save());

            // Restoring to a previous state
            editor.Restore(history.Pop()); // Restores "Hello, Design Patterns!"
            editor.Restore(history.Pop()); // Restores "Hello, World!"
        }
    }
}
