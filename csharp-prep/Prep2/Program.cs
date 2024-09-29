using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"{Date} | {Prompt} | {Response}";
    }
}

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    // Lista de prompts simples
    private List<string> _prompts = new List<string>
    {
        "What made you smile today?",
        "What was a challenge you faced today?",
        "What did you learn today?",
        "What are you grateful for today?",
        "What was a memorable moment today?"
    };

    // Método simplificado para adicionar uma nova entrada
    public void AddEntry()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        // Utilizando a data atual
        string currentDate = DateTime.Now.ToShortDateString();

        _entries.Add(new Entry(prompt, response, currentDate));
        Console.WriteLine("Entry added.\n");
    }

    // Exibir entradas
    public void DisplayEntries()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    // Método simplificado para salvar o diário
    public void SaveJournalToFile()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                outputFile.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }

        Console.WriteLine("Journal saved.\n");
    }

    // Método simplificado para carregar o diário
    public void LoadJournalFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    _entries.Add(new Entry(parts[1], parts[2], parts[0]));
                }
            }

            Console.WriteLine("Journal loaded.\n");
        }
        else
        {
            Console.WriteLine("File not found.\n");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. View Journal");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveJournalToFile();
                    break;
                case "4":
                    journal.LoadJournalFromFile();
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice.\n");
                    break;
            }
        }
    }
}
