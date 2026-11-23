using System;
using System.Collections.Generic;

// EXCEEDING REQUIREMENTS / CREATIVITY:
// 1. Non-repeating prompt and question cycling: Prompts and reflection questions are shuffled
//    and cycled through without repeats until all items in the list have been used in the session.
// 2. Session activity log: Tracks how many times each activity was completed during the current
//    run and displays a summary when the user exits the program.
// 3. Safe input & remaining-time handling: Validates menu and duration inputs and stops
//    breathing/reflection loops cleanly right when the chosen duration is reached.

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> activityCounts = new Dictionary<string, int>
        {
            { "Breathing", 0 },
            { "Reflecting", 0 },
            { "Listing", 0 }
        };

        List<string> breathingPrompts = new List<string>
        {
            "Breathe in...",
            "Breathe out..."
        };

        List<string> reflectingPrompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        List<string> reflectingQuestions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        List<string> listingPrompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine()?.Trim() ?? "";

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity(
                        "Breathing Activity",
                        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",
                        breathingPrompts
                    );
                    breathing.Run();
                    activityCounts["Breathing"]++;
                    break;

                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity(
                        "Reflecting Activity",
                        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
                        reflectingPrompts,
                        reflectingQuestions
                    );
                    reflecting.Run();
                    activityCounts["Reflecting"]++;
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity(
                        "Listing Activity",
                        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
                        listingPrompts
                    );
                    listing.Run();
                    activityCounts["Listing"]++;
                    break;

                case "4":
                    running = false;
                    break;

                default:
                    Console.WriteLine("\nPlease enter a number between 1 and 4.");
                    Thread.Sleep(1500);
                    break;
            }
        }

        Console.Clear();
        Console.WriteLine("Session Summary:");
        Console.WriteLine($"  Breathing Activity : {activityCounts["Breathing"]}");
        Console.WriteLine($"  Reflecting Activity: {activityCounts["Reflecting"]}");
        Console.WriteLine($"  Listing Activity   : {activityCounts["Listing"]}");
        Console.WriteLine("\nThank you for practicing mindfulness. Take care!");
    }
}