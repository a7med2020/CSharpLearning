using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class Cryptography
{
    // Method to encrypt a plain text string
    public static string EncryptString(string plainText, string key)
    {
        // Convert the key and plain text to byte arrays
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] iv = new byte[16]; // AES requires a 16-byte IV (Initialization Vector)

        using (Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.IV = iv;

            // Create an encryptor and a memory stream to store the encrypted data
            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            using (var memoryStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                using (var streamWriter = new StreamWriter(cryptoStream))
                {
                    streamWriter.Write(plainText);
                }

                // Convert the encrypted data to a Base64 string and return it
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
    }

    // Method to decrypt an encrypted string
    public static string DecryptString(string encryptedText, string key)
    {
        // Convert the key and encrypted text to byte arrays
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] iv = new byte[16]; // AES requires a 16-byte IV
        byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.IV = iv;

            // Create a decryptor and a memory stream to store the decrypted data
            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            using (var memoryStream = new MemoryStream(cipherTextBytes))
            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            using (var streamReader = new StreamReader(cryptoStream))
            {
                // Read the decrypted data from the stream and return it
                return streamReader.ReadToEnd();
            }
        }
    }

    public static void Execute()
    {
        // Example usage
        string original = "Hello, World!" ;

         
        string key = "ThisIsAKey123456"; // AES requires a 16-byte key

        Console.WriteLine($"Original: {original}");

        // Encrypt the original string
        string encrypted = EncryptString(original, key);
        Console.WriteLine($"Encrypted: {encrypted}");

        // Decrypt the encrypted string
        string decrypted = DecryptString(encrypted, key);
        Console.WriteLine($"Decrypted: {decrypted}");
    }
}
