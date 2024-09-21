using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int percent = int.Parse(Console.ReadLine());

        string letter = percent >= 90 ? "A" :
                        percent >= 80 ? "B" :
                        percent >= 70 ? "C" :
                        percent >= 60 ? "D" : "F";

        Console.WriteLine($"Your grade is: {letter}");

        Console.WriteLine(percent >= 70 ? "You passed!" : "Better luck next time!");
    }
}
