using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;  // Added a new field to enhance my journal program

    public Entry(string prompt, string entry, string mood)
    {
        _date = DateTime.Now.ToShortDateString();
        _promptText = prompt;
        _entryText = entry;
        _mood = mood;
    }

    public override string ToString()
    {
        return $"{_date} - {_promptText}\nMood: {_mood}\nEntry: {_entryText}\n";
    }

    public string ToCsvString()
    {
        return $"\"{_date}\",\"{_promptText}\",\"{_mood}\",\"{_entryText}\"";
    }

    public static Entry FromCsvString(string line)
    {
        string[] parts = line.Split(new[] { "\",\"" }, StringSplitOptions.None);
        return new Entry(parts[1].Trim('"'), parts[3].Trim('"'), parts[2].Trim('"')) { _date = parts[0].Trim('"') };
    }
}
