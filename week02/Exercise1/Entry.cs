using System;

class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;

    public Entry()
    {
        _date = "";
        _promptText = "";
        _entryText = "";
        _mood = "";
    }

    public Entry(string date, string promptText, string entryText, string mood)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }

    public string GetFileString()
    {
        return $"{_date}|{_promptText}|{_entryText}|{_mood}";
    }
}
