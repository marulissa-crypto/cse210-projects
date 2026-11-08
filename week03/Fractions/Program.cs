using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create instances using the 3 constructors
        Fraction f1 = new Fraction();          // 1/1
        Fraction f2 = new Fraction(5);         // 5/1
        Fraction f3 = new Fraction(3, 4);      // 3/4
        Fraction f4 = new Fraction(1, 3);      // 1/3

        // 2. Display fractional and decimal representations (matches sample output)
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // 3. Test Getters and Setters
        Console.WriteLine("\n--- Testing Getters and Setters ---");
        Fraction testFraction = new Fraction();
        
        testFraction.SetTop(6);
        testFraction.SetBottom(7);

        Console.WriteLine($"Top: {testFraction.GetTop()}");
        Console.WriteLine($"Bottom: {testFraction.GetBottom()}");
        Console.WriteLine($"Fraction: {testFraction.GetFractionString()}");
        Console.WriteLine($"Decimal: {testFraction.GetDecimalValue()}");
    }
}