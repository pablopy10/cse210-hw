using System;
using System.Collections.Generic;

class Goal
{
    protected string name;
    protected int points;
    protected bool isComplete;

    public Goal(string name, int points)
    {
        this.name = name;
        this.points = points;
        this.isComplete = false;
    }

    public virtual void RecordEvent()
    {
        isComplete = true;
    }

    public virtual string DisplayGoal()
    {
        return $"[ {(isComplete ? "X" : " ")} ] {name} - {points} points";
    }

    public int GetPoints()
    {
        return points;
    }

    public bool IsComplete()
    {
        return isComplete;
    }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        // No completion for EternalGoal; points added each time.
    }

    public override string DisplayGoal()
    {
        return $"[ ∞ ] {name} - {points} points (Eternal)";
    }
}

class ChecklistGoal : Goal
{
    private int targetCount;
    private int completedCount;
    private int bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints)
        : base(name, points)
    {
        this.targetCount = targetCount;
        this.completedCount = 0;
        this.bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        if (completedCount < targetCount)
        {
            completedCount++;
            if (completedCount == targetCount)
            {
                isComplete = true;
            }
        }
    }

    public override string DisplayGoal()
    {
        return $"[ {(isComplete ? "X" : " ")} ] {name} - {points} points each (Completed {completedCount}/{targetCount}, Bonus: {bonusPoints} points)";
    }
}

class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int totalScore = 0;

    public void CreateGoal()
    {
        Console.WriteLine("Select Goal Type: 1. Simple  2. Eternal  3. Checklist");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                goals.Add(new SimpleGoal(name, points));
                break;
            case 2:
                goals.Add(new EternalGoal(name, points));
                break;
            case 3:
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());

                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());

                goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints));
                break;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Choose a goal to record an event:");
        DisplayGoals();

        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].RecordEvent();
            totalScore += goals[goalIndex].GetPoints();
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].DisplayGoal()}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Total Score: {totalScore} points");
    }
}

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Create New Goal\n2. Record Event\n3. Display Goals\n4. Display Score\n5. Exit");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    manager.CreateGoal();
                    break;
                case 2:
                    manager.RecordEvent();
                    break;
                case 3:
                    manager.DisplayGoals();
                    break;
                case 4:
                    manager.DisplayScore();
                    break;
                case 5:
                    running = false;
                    break;
            }
        }
    }
}
