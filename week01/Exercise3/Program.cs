using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirement 3: Generate a random number from 1 to 100
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        // Core Requirement 2: Loop that keeps running until the guess matches the magic number
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            string? input = Console.ReadLine();
            guess = int.Parse(input ?? "0");

            // Core Requirement 1 & 3: Compare guess to the magic number using if statements
            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}