using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry(string prompt, string entry)
    {
        _date = DateTime.Now.ToShortDateString();
        _promptText = prompt;
        _entryText = entry;
    }

    public override string ToString()
    {
        return $"{_date} - Prompt: {_promptText}\nEntry: {_entryText}\n";
    }

    public string ToFileString()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split('|');
        return new Entry(parts[1], parts[2]) { _date = parts[0] };
    }
}
