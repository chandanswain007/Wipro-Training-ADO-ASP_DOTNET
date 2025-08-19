using SecureAppl;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Secure Application Demo ---");

        var userService = new UserService();

        // 1. Register a new user
        Console.WriteLine("\n[1] Registering a new user 'admin'...");
        try
        {
            userService.Register("admin", "securePass123!");
            Console.WriteLine("User 'admin' registered successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during registration: {ex.Message}");
        }

        // 2. Authenticate the user (Success)
        Console.WriteLine("\n[2] Authenticating 'admin' with correct password...");
        bool isAuthenticated = userService.Authenticate("admin", "securePass123!");
        Console.WriteLine($"Authentication successful: {isAuthenticated}"); // Expected: True

        // 3. Authenticate with wrong password (Failure)
        Console.WriteLine("\n[3] Authenticating 'admin' with wrong password...");
        isAuthenticated = userService.Authenticate("admin", "wrongPassword");
        Console.WriteLine($"Authentication successful: {isAuthenticated}"); // Expected: False

        // 4. Demonstrate Encryption/Decryption
        Console.WriteLine("\n[4] Encrypting and decrypting sensitive data...");
        string sensitiveData = "User Email: admin@example.com";
        Console.WriteLine($"Original data: {sensitiveData}");

        string encryptedData = EncryptionHelper.Encrypt(sensitiveData);
        Console.WriteLine($"Encrypted data: {encryptedData}");

        string decryptedData = EncryptionHelper.Decrypt(encryptedData);
        Console.WriteLine($"Decrypted data: {decryptedData}");

        Console.WriteLine("\n--- Demo Finished ---");
    }
}