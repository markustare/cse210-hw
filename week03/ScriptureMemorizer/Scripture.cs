using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()} - {string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }

    public void HideRandomWords()
    {
        Random rand = new Random();
        var visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        if (visibleWords.Count > 0)
        {
            int wordsToHide = Math.Max(1, visibleWords.Count / 3);
            for (int i = 0; i < wordsToHide; i++)
            {
                visibleWords[rand.Next(visibleWords.Count)].Hide();
            }
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}