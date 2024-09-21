using System;

class Program
{
    static void Main(string[] args)
    {
        string first = GetInput("What is your first name? ");
        string last = GetInput("What is your last name? ");

        PrintFullName(first, last);
    }

    static string GetInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    static void PrintFullName(string first, string last)
    {
        Console.WriteLine($"Your name is {last}, {first} {last}.");
    }
}
