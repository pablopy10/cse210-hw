using System;
using System.Threading;

class MindfulnessActivity
{
    protected string activityName;
    protected string description;
    protected int duration;

    public void StartActivity()
    {
        Console.WriteLine($"Starting {activityName}");
        Console.WriteLine(description);
        Console.Write("Enter the duration of the activity in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("Good job! You have completed the activity.");
        Console.WriteLine($"You spent {duration} seconds on the {activityName}.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(500);
            Console.Write("\b");
            Console.Write("-");
            Thread.Sleep(500);
            Console.Write("\b");
        }
        Console.WriteLine();
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        activityName = "Breathing Activity";
        description = "This activity will help you relax by pacing your breathing.";
    }

    public void RunBreathingExercise()
    {
        StartActivity();

        int secondsElapsed = 0;
        while (secondsElapsed < duration)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(2);
            Console.WriteLine("Breathe out...");
            ShowSpinner(2);
            secondsElapsed += 4;
        }

        EndActivity();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you did something difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you stood up for yourself.",
        "Think of a time when you were very proud of yourself."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "What did you learn from this experience?",
        "How did you feel when it was over?",
        "What can you learn from this for future situations?"
    };

    public ReflectionActivity()
    {
        activityName = "Reflection Activity";
        description = "This activity will help you reflect on a time when you demonstrated strength or resilience.";
    }

    public void RunReflectionExercise()
    {
        StartActivity();

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);
        ShowSpinner(3);

        int secondsElapsed = 0;
        while (secondsElapsed < duration)
        {
            string question = questions[rand.Next(questions.Length)];
            Console.WriteLine(question);
            ShowSpinner(4);
            secondsElapsed += 4;
        }

        EndActivity();
    }
}

class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "List as many people as you are grateful for.",
        "List your personal strengths.",
        "List the good things that happened this week."
    };

    public ListingActivity()
    {
        activityName = "Listing Activity";
        description = "This activity will help you list things you are grateful for or that make you happy.";
    }

    public void RunListingExercise()
    {
        StartActivity();

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Console.WriteLine("Start listing items:");
        ShowSpinner(3);

        int itemCount = 0;
        int secondsElapsed = 0;
        while (secondsElapsed < duration)
        {
            Console.Write("- ");
            Console.ReadLine();
            itemCount++;
            secondsElapsed += 3;
        }

        Console.WriteLine($"You listed {itemCount} items.");
        EndActivity();
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities");
            Console.WriteLine("1. Breathing Exercise");
            Console.WriteLine("2. Reflection Exercise");
            Console.WriteLine("3. Listing Exercise");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.RunBreathingExercise();
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.RunReflectionExercise();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.RunListingExercise();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }
}
