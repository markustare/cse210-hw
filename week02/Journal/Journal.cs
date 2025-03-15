using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private PromptGenerator _promptGenerator = new PromptGenerator();

    public void AddEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();

        Console.WriteLine("\nPrompt: " + prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Console.Write("How did you feel today? (e.g., Happy, Sad, Excited, Anxious): ");
        string mood = Console.ReadLine();

        _entries.Add(new Entry(prompt, response, mood));
        Console.WriteLine("Entry added successfully.");
    }

    public void DisplayJournal()
    {
        Console.WriteLine("\n--- Journal Entries ---");
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToCsv()
    {
        Console.Write("Enter filename to save (with .csv extension): ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("\"Date\",\"Prompt\",\"Mood\",\"Entry\"");
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToCsvString());
            }
        }
        Console.WriteLine("Journal saved successfully as CSV.");
    }

    public void LoadFromCsv()
    {
        Console.Write("Enter filename to load (with .csv extension): ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);

            for (int i = 1; i < lines.Length; i++) // Skips header row of the CSV file
            {
                _entries.Add(Entry.FromCsvString(lines[i]));
            }
            Console.WriteLine("Journal loaded successfully from CSV.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public void DisplaySummary()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries available for summary.");
            return;
        }

        Dictionary<string, int> moodCounts = new Dictionary<string, int>();

        foreach (Entry entry in _entries)
        {
            if (moodCounts.ContainsKey(entry._mood))
                moodCounts[entry._mood]++;
            else
                moodCounts[entry._mood] = 1;
        }

        Console.WriteLine("\n--- Mood Summary ---");
        foreach (var mood in moodCounts)
        {
            Console.WriteLine($"{mood.Key}: {mood.Value} times");
        }
    }
}
