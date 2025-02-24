#r "System.Security.Cryptography"

using System;
using System.Security.Cryptography;

string GenerateSecureTokenKey()
{
    using var rng = RandomNumberGenerator.Create();
    byte[] key = new byte[64];
    rng.GetBytes(key);
    return Convert.ToBase64String(key);
}

Console.WriteLine("Generated Secure Token Key:");
Console.WriteLine(GenerateSecureTokenKey());
