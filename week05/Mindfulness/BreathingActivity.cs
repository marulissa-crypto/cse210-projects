using System;
using System.Collections.Generic;

public class BreathingActivity : Activity
{
    private List<string> _prompts;
    private readonly Queue<string> _promptDeck = new Queue<string>();

    public BreathingActivity(string name, string description, List<string> prompts, int duration = 30)
        : base(name, description, duration)
    {
        _prompts = prompts;
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        int stepIndex = 0;

        while (DateTime.Now < endTime)
        {
            double remainingSeconds = (endTime - DateTime.Now).TotalSeconds;
            if (remainingSeconds <= 0.5)
            {
                break;
            }

            // Alternate smoothly between "Breathe in..." and "Breathe out..."
            string prompt = _prompts != null && _prompts.Count > 0
                ? _prompts[stepIndex % _prompts.Count]
                : (stepIndex % 2 == 0 ? "Breathe in..." : "Breathe out...");

            int phaseSeconds = (int)Math.Ceiling(remainingSeconds);
            int targetPhase = stepIndex % 2 == 0 ? 4 : 6;
            phaseSeconds = Math.Min(targetPhase, Math.Max(1, phaseSeconds));

            Console.Write($"\n{prompt}");
            ShowCountdown(phaseSeconds);
            Console.WriteLine();

            stepIndex++;
        }

        DisplayEndingMessage();
    }
}