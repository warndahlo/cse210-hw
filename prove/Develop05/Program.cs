using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public abstract void RecordProgress();
    public abstract string DisplayProgress();
}

class SimpleGoal : Goal
{
    public bool IsCompleted { get; set; }  // Changed to public setter

    public override void RecordProgress()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
        }
        else
        {
            Console.WriteLine("This goal is already completed.");
        }
    }

    public override string DisplayProgress()
    {
        return IsCompleted ? "[X]" : "[ ]";
    }
}

class EternalGoal : Goal
{
    public override void RecordProgress()
    {
        Console.WriteLine($"Recorded progress for '{Name}'. You earned {Points} points.");
    }

    public override string DisplayProgress()
    {
        return "[∞]"; // Infinite progress
    }
}

class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }  // Changed to public setter
    public int BonusPoints { get; set; }

    public override void RecordProgress()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            int totalPoints = Points;
            if (CurrentCount == TargetCount)
            {
                totalPoints += BonusPoints;
                Console.WriteLine($"Congratulations! You completed '{Name}' and earned a bonus of {BonusPoints} points!");
            }
            Console.WriteLine($"Recorded progress for '{Name}'. You earned {totalPoints} points.");
        }
        else
        {
            Console.WriteLine("This goal is already fully completed.");
        }
    }

    public override string DisplayProgress()
    {
        return $"[{CurrentCount}/{TargetCount}]";
    }
}

class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private const string FileName = "goals.txt";

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void ListGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].DisplayProgress()} {goals[i].Name} - {goals[i].Description}");
        }
    }

    public void RecordGoalProgress(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].RecordProgress();
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter(FileName))
        {
            foreach (var goal in goals)
            {
                if (goal is SimpleGoal simpleGoal)
                    writer.WriteLine($"Simple|{simpleGoal.Name}|{simpleGoal.Description}|{simpleGoal.Points}|{simpleGoal.IsCompleted}");
                else if (goal is EternalGoal eternalGoal)
                    writer.WriteLine($"Eternal|{eternalGoal.Name}|{eternalGoal.Description}|{eternalGoal.Points}");
                else if (goal is ChecklistGoal checklistGoal)
                    writer.WriteLine($"Checklist|{checklistGoal.Name}|{checklistGoal.Description}|{checklistGoal.Points}|{checklistGoal.TargetCount}|{checklistGoal.CurrentCount}|{checklistGoal.BonusPoints}");
            }
        }
    }

    public void LoadGoals()
    {
        if (File.Exists(FileName))
        {
            string[] lines = File.ReadAllLines(FileName);
            foreach (var line in lines)
            {
                string[] parts = line.Split('|');
                if (parts[0] == "Simple")
                {
                    goals.Add(new SimpleGoal { Name = parts[1], Description = parts[2], Points = int.Parse(parts[3]), IsCompleted = bool.Parse(parts[4]) });
                }
                else if (parts[0] == "Eternal")
                {
                    goals.Add(new EternalGoal { Name = parts[1], Description = parts[2], Points = int.Parse(parts[3]) });
                }
                else if (parts[0] == "Checklist")
                {
                    goals.Add(new ChecklistGoal { Name = parts[1], Description = parts[2], Points = int.Parse(parts[3]), TargetCount = int.Parse(parts[4]), CurrentCount = int.Parse(parts[5]), BonusPoints = int.Parse(parts[6]) });
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        manager.LoadGoals();
        
        while (true)
        {
            Console.WriteLine("\nEternal Quest - Goal Tracker");
            Console.WriteLine("1. Add a goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record goal progress");
            Console.WriteLine("4. Save and exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter goal name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter goal description: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter points for completing this goal: ");
                    int points = int.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine("Choose goal type: 1) Simple 2) Eternal 3) Checklist");
                    string typeChoice = Console.ReadLine();
                    
                    if (typeChoice == "1")
                    {
                        manager.AddGoal(new SimpleGoal { Name = name, Description = description, Points = points });
                    }
                    else if (typeChoice == "2")
                    {
                        manager.AddGoal(new EternalGoal { Name = name, Description = description, Points = points });
                    }
                    else if (typeChoice == "3")
                    {
                        Console.Write("Enter target count: ");
                        int target = int.Parse(Console.ReadLine() ?? "1");
                        Console.Write("Enter bonus points for completing all: ");
                        int bonusPoints = int.Parse(Console.ReadLine() ?? "0");
                        manager.AddGoal(new ChecklistGoal { Name = name, Description = description, Points = points, TargetCount = target, BonusPoints = bonusPoints });
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }
                    break;
                case "2":
                    manager.ListGoals();
                    break;
                case "3":
                    manager.ListGoals();
                    Console.Write("Enter goal number: ");
                    int index = int.Parse(Console.ReadLine() ?? "-1") - 1;
                    manager.RecordGoalProgress(index);
                    break;
                case "4":
                    manager.SaveGoals();
                    Console.WriteLine("Goals saved. Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }
}
