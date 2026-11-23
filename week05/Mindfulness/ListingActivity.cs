using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private readonly Queue<string> _promptDeck = new Queue<string>();
    private int _count;

    public ListingActivity(string name, string description, List<string> prompts, int duration = 30)
        : base(name, description, duration)
    {
        _prompts = prompts;
        _count = 0;
    }

    public void Run()
    {
        DisplayStartingMessage();

        _count = 0;
        GetRandomPrompt();

        Console.Write("\nYou may begin in: ");
        ShowCountdown(5);
        Console.WriteLine("\nStart listing items (press Enter after each one):");

        List<string> items = GetListFromUser();
        _count = items.Count;

        Console.WriteLine($"\nYou listed {_count} item{(_count == 1 ? "" : "s")}!");

        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        string prompt = PickFromDeck(_prompts, _promptDeck);
        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        Console.WriteLine($" --- {prompt} ---");
    }

    public List<string> GetListFromUser()
    {
        List<string> entries = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string line = Console.ReadLine();

            // Check clock both before and after ReadLine so the session ends promptly
            if (DateTime.Now >= endTime)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    entries.Add(line.Trim());
                }
                break;
            }

            if (!string.IsNullOrWhiteSpace(line))
            {
                entries.Add(line.Trim());
            }
        }

        return entries;
    }
}