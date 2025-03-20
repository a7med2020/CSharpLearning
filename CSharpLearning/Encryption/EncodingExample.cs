using System;
using System.Text;

public class EncodingExample
{
    public static void Execute()
    {
        string original = "Hello";

        // Encode the string as ASCII bytes
        byte[] asciiBytes = Encoding.ASCII.GetBytes(original);
        Console.WriteLine("ASCII Encoding:");
        foreach (byte b in asciiBytes)
        {
            Console.Write(b + " ");
        }
        Console.WriteLine();

        // Encode the string as UTF-8 bytes
        byte[] utf8Bytes = Encoding.UTF8.GetBytes(original);
        Console.WriteLine("UTF-8 Encoding:");
        foreach (byte b in utf8Bytes)
        {
            Console.Write(b + " ");
        }
        Console.WriteLine();

        // Encode the string as UTF-16 (Unicode) bytes
        byte[] utf16Bytes = Encoding.Unicode.GetBytes(original);
        Console.WriteLine("UTF-16 Encoding:");
        foreach (byte b in utf16Bytes)
        {
            Console.Write(b + " ");
        }
        Console.WriteLine();
    }
}
