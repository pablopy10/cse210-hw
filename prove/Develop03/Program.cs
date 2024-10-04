using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create scripture and reference
        Scripture myScripture = new Scripture(new Reference("Proverbs", "3:5-6"), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");

        // Keep going until all words are hidden
        while (!myScripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(myScripture.GetScripture()); // Show scripture
            Console.WriteLine("\nPress enter to hide words or type 'quit' to stop:");
            string input = Console.ReadLine();
            if (input == "quit") break; // Stop if user types quit
            myScripture.HideSomeWords(); // Hide some words
        }
    }
}

// Class for the scripture
class Scripture
{
    private Reference myReference;
    private List<Word> wordsList;

    public Scripture(Reference reference, string scriptureText)
    {
        myReference = reference;
        wordsList = scriptureText.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideSomeWords()
    {
        Random random = new Random();
        for (int i = 0; i < 3; i++) // Hide 3 words each time
        {
            int index = random.Next(wordsList.Count);
            wordsList[index].HideWord();
        }
    }

    public string GetScripture()
    {
        string fullScripture = myReference.GetReference() + " "; // Add reference
        fullScripture += string.Join(" ", wordsList.Select(word => word.GetWord())); // Add words
        return fullScripture;
    }

    public bool AllWordsHidden()
    {
        return wordsList.All(word => word.IsHidden()); // Check if all words are hidden
    }
}

// Class for the reference
class Reference
{
    private string book;
    private string verse;

    public Reference(string book, string verse)
    {
        this.book = book;
        this.verse = verse;
    }

    public string GetReference()
    {
        return book + " " + verse;
    }
}

// Class for individual words
class Word
{
    private string wordText;
    private bool isHidden;

    public Word(string text)
    {
        wordText = text;
        isHidden = false;
    }

    public void HideWord()
    {
        isHidden = true; // Hide the word
    }

    public string GetWord()
    {
        return isHidden ? "____" : wordText; // Show blank if hidden
    }

    public bool IsHidden()
    {
        return isHidden;
    }
}
