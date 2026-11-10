
using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        _words = text.Split(
            new char[] { ' ', '\n', '\r', '\t' },
            StringSplitOptions.RemoveEmptyEntries
        )
        .Select(word => new Word(word))
        .ToList();

        _random = new Random();
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();

        string scriptureText = string.Join(
            " ",
            _words.Select(word => word.GetDisplayText())
        );

        return $"{referenceText}\n{scriptureText}";
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = _words
            .Where(word => !word.IsHidden())
            .ToList();

        int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = _random.Next(visibleWords.Count);

            visibleWords[randomIndex].Hide();

            visibleWords.RemoveAt(randomIndex);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public int GetHiddenWordCount()
    {
        return _words.Count(word => word.IsHidden());
    }

    public int GetTotalWordCount()
    {
        return _words.Count;
    }

    // Resets all words when the scripture is selected again.
    public void Reset()
    {
        foreach (Word word in _words)
        {
            word.Show();
        }
    }
}
