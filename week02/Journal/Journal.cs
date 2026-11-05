using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> Entries { get; set; } = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        Entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("The journal is currently empty.\n");
            return;
        }

        foreach (Entry entry in Entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("Date,Prompt,Response,Mood");
            foreach (Entry entry in Entries)
            {
                string cleanDate = $"\"{entry.Date.Replace("\"", "\"\"")}\"";
                string cleanPrompt = $"\"{entry.PromptText.Replace("\"", "\"\"")}\"";
                string cleanResponse = $"\"{entry.EntryText.Replace("\"", "\"\"")}\"";
                string cleanMood = $"\"{entry.Mood.Replace("\"", "\"\"")}\"";

                outputFile.WriteLine($"{cleanDate},{cleanPrompt},{cleanResponse},{cleanMood}");
            }
        }
        Console.WriteLine("Journal saved successfully as a CSV file.\n");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        Entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        bool isHeader = true;
        foreach (string line in lines)
        {
            if (isHeader)
            {
                isHeader = false;
                continue;
            }

            List<string> parts = ParseCsvLine(line);
            if (parts.Count >= 4)
            {
                Entry entry = new Entry(parts[0], parts[1], parts[2], parts[3]);
                Entries.Add(entry);
            }
        }
        Console.WriteLine("Journal loaded successfully from file.\n");
    }

    private List<string> ParseCsvLine(string line)
    {
        List<string> result = new List<string>();
        bool inQuotes = false;
        string currentField = "";

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (c == '"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                {
                    currentField += '"';
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (c == ',' && !inQuotes)
            {
                result.Add(currentField);
                currentField = "";
            }
            else
            {
                currentField += c;
            }
        }
        result.Add(currentField);
        return result;
    }
}