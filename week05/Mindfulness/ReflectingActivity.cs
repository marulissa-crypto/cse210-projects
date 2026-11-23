using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private readonly Queue<string> _promptDeck = new Queue<string>();
    private readonly Queue<string> _questionDeck = new Queue<string>();

    public ReflectingActivity(
        string name,
        string description,
        List<string> prompts,
        List<string> questions,
        int duration = 30)
        : base(name, description, duration)
    {
        _prompts = prompts;
        _questions = questions;
    }

    public void Run()
    {
        DisplayStartingMessage();

        DisplayPrompt();
        Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            double remaining = (endTime - DateTime.Now).TotalSeconds;
            if (remaining <= 0.5)
            {
                break;
            }

            DisplayQuestion();
            int pauseSeconds = Math.Min(8, Math.Max(1, (int)Math.Ceiling(remaining)));
            ShowSpinner(pauseSeconds);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return PickFromDeck(_prompts, _promptDeck);
    }

    private string GetRandomQuestion()
    {
        return PickFromDeck(_questions, _questionDeck);
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
    }

    public void DisplayQuestion()
    {
        Console.Write($"> {GetRandomQuestion()} ");
    }
}