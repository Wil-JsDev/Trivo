using System.Security.Cryptography;

namespace Trivo.Application.Utils;

public static class CodeGenerator
{
    /// <summary>
    /// Generates a random numeric token with the specified number of digits.
    /// </summary>
    /// <param name="digits">Number of digits for the token (default is 6). Must be between 1 and 9.</param>
    /// <returns>A numeric token as a string.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the number of digits is outside the allowed range.</exception>
    public static string GenerateNumericCode(int digits = 6)
    {
        if (digits is <= 0 or > 9)
            throw new ArgumentOutOfRangeException(nameof(digits), "Digits must be between 1 and 9.");

        var max = (int)Math.Pow(10, digits); // E.g.: 1,000,000 for 6 digits
        var min = (int)Math.Pow(10, digits - 1); // E.g.: 100,000 for 6 digits

        using var generator = RandomNumberGenerator.Create();
        var bytes = new byte[4]; // int = 4 bytes

        int number;
        do
        {
            generator.GetBytes(bytes);
            number = BitConverter.ToInt32(bytes, 0) & int.MaxValue; // Ensures it is positive
        } while (number < min || number >= max);

        return number.ToString();
    }
}