
using System;
using System.Collections.Generic;

// CREATIVITY AND EXCEEDING REQUIREMENTS:
//
// 1. Added a library of multiple scriptures.
// 2. Scriptures are selected randomly.
// 3. Added Easy, Medium and Hard difficulty levels.
// 4. Added a progress indicator.
// 5. Added a replay option.
// 6. Only words that have not already been hidden are selected.
// 7. Added a reset feature for replaying scriptures.
// 8. Supports both single verses and verse ranges.

bool playAgain = true;

List<Scripture> scriptureLibrary = new List<Scripture>
{
    new Scripture(
        new Reference("John", 3, 16),
        "For God so loved the world that he gave his only begotten Son " +
        "that whosoever believeth in him should not perish but have " +
        "everlasting life."
    ),

    new Scripture(
        new Reference("Proverbs", 3, 5, 6),
        "Trust in the Lord with all thine heart and lean not unto " +
        "thine own understanding. In all thy ways acknowledge him " +
        "and he shall direct thy paths."
    ),

    new Scripture(
        new Reference("Philippians", 4, 13),
        "I can do all things through Christ which strengtheneth me."
    ),

    new Scripture(
        new Reference("Psalm", 23, 1),
        "The Lord is my shepherd I shall not want."
    )
};

Random random = new Random();

while (playAgain)
{
    // Randomly select a scripture.
    Scripture selectedScripture =
        scriptureLibrary[random.Next(scriptureLibrary.Count)];

    // Make sure all words are visible at the beginning.
    selectedScripture.Reset();

    Console.Clear();

    Console.WriteLine("====================================");
    Console.WriteLine("       SCRIPTURE MEMORIZER");
    Console.WriteLine("====================================");

    Console.WriteLine("\nChoose your difficulty:");
    Console.WriteLine("1. Easy - Hide 2 words at a time");
    Console.WriteLine("2. Medium - Hide 4 words at a time");
    Console.WriteLine("3. Hard - Hide 6 words at a time");

    Console.Write("\nEnter your choice: ");

    string choice = Console.ReadLine() ?? "";

    int wordsToHide = choice switch
    {
        "1" => 2,
        "2" => 4,
        "3" => 6,
        _ => 2
    };

    bool finished = false;

    while (!finished)
    {
        Console.Clear();

        Console.WriteLine("====================================");
        Console.WriteLine("       SCRIPTURE MEMORIZER");
        Console.WriteLine("====================================\n");

        // Display the scripture.
        Console.WriteLine(selectedScripture.GetDisplayText());

        Console.WriteLine("\n------------------------------------");

        // Display memorisation progress.
        Console.WriteLine(
            $"Hidden words: {selectedScripture.GetHiddenWordCount()} " +
            $"out of {selectedScripture.GetTotalWordCount()}"
        );

        Console.WriteLine("------------------------------------");

        // Stop when every word has been hidden.
        if (selectedScripture.AllWordsHidden())
        {
            Console.WriteLine("\nCongratulations!");
            Console.WriteLine("You have hidden all the words.");

            finished = true;
            continue;
        }

        Console.WriteLine(
            "\nPress ENTER to hide more words or type 'quit' to exit."
        );

        string input = Console.ReadLine() ?? "";

        if (input.Trim().Equals(
            "quit",
            StringComparison.OrdinalIgnoreCase))
        {
            finished = true;
            playAgain = false;
        }
        else if (string.IsNullOrWhiteSpace(input))
        {
            selectedScripture.HideRandomWords(wordsToHide);
        }
        else
        {
            Console.WriteLine(
                "Please press ENTER or type 'quit'."
            );

            Console.ReadLine();
        }
    }

    // Offer the user another scripture.
    if (playAgain)
    {
        Console.Write(
            "\nWould you like to memorise another scripture? (yes/no): "
        );

        string answer = Console.ReadLine() ?? "";

        if (!answer.Trim().Equals(
            "yes",
            StringComparison.OrdinalIgnoreCase) &&
            !answer.Trim().Equals(
            "y",
            StringComparison.OrdinalIgnoreCase))
        {
            playAgain = false;
        }
    }
}

Console.Clear();

Console.WriteLine("Thank you for using Scripture Memorizer!");
Console.WriteLine("Keep learning and keep the Word in your heart.");
