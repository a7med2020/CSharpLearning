using System;
using System.Security.Cryptography;
using System.Text;

public class SHA256Hashing
{

    //SHA-256 is a cryptographic hash function that generates a fixed-size 256 - bit(32 - byte) hash value from any input data.It is commonly
    //used for ensuring data integrity, storing passwords securely, and in various cryptographic applications.

    // Method to compute the SHA-256 hash of a string
    public static string ComputeSha256Hash(string rawData)
    {
        // Create a SHA256 object
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // Compute the hash as a byte array
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // Convert the byte array to a hexadecimal string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }

    public static void Execute()
    {
        // Example usage
        string original = "Hello, World! SHA-256 is a cryptographic hash function that generates a fixed-size 256-bit (32-byte) hash value from any input data. It is commonly used for ensuring data integrity, storing passwords securely, and in various cryptographic applications.";
        string hash = ComputeSha256Hash(original);

        Console.WriteLine($"Original: {original}");
        Console.WriteLine($"SHA-256 Hash: {hash}");
    }
}
