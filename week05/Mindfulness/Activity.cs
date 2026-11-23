using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private readonly Random _random = new Random();

    public Activity(string name, string description, int duration = 30)
    {
        _name = name;
        _description = description;
        _duration = duration > 0 ? duration : 30;
    }

    protected int Duration
    {
        get { return _duration; }
        set { _duration = value > 0 ? value : 30; }
    }

    protected Random RandomGenerator => _random;

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, in seconds, would you like for your session? ");

        string input = Console.ReadLine()?.Trim() ?? "";
        while (!int.TryParse(input, out int seconds) || seconds <= 0)
        {
            Console.Write("Please enter a positive whole number of seconds: ");
            input = Console.ReadLine()?.Trim() ?? "";
        }
        _duration = int.Parse(input);

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(4);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(4);
    }

    public void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            string frame = frames[index % frames.Length];
            Console.Write(frame);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index++;
        }
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            string label = i.ToString();
            Console.Write(label);
            Thread.Sleep(1000);

            // Erase exact number of digits printed (handles 1-digit and 2-digit counts)
            for (int d = 0; d < label.Length; d++)
            {
                Console.Write("\b \b");
            }
        }
    }

    protected string PickFromDeck(List<string> source, Queue<string> deck)
    {
        if (source == null || source.Count == 0)
        {
            return "";
        }

        if (deck.Count == 0)
        {
            List<string> copy = new List<string>(source);
            for (int i = copy.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                (copy[i], copy[j]) = (copy[j], copy[i]);
            }

            foreach (string item in copy)
            {
                deck.Enqueue(item);
            }
        }

        return deck.Dequeue();
    }
}