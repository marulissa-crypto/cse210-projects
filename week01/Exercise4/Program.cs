using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userNumber = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Loop to collect numbers until the user enters 0
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            string? response = Console.ReadLine();
            userNumber = int.Parse(response ?? "0");

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Core Requirement 1: Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Core Requirement 2: Compute the average
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Core Requirement 3: Find the maximum number
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The largest number is: {max}");
    }
}