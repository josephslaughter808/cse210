using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Exceeded requirements by adding a simple level system.
        // The user levels up every 1000 points and the level is displayed with the score.
        List<Goal> goals = new List<Goal>();
        int score = 0;
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine($"You have {score} points.");
            Console.WriteLine($"Level: {GetLevel(score)}");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine();

            if (choice == 1)
            {
                CreateGoal(goals);
            }
            else if (choice == 2)
            {
                ListGoals(goals);
            }
            else if (choice == 3)
            {
                SaveGoals(goals, score);
            }
            else if (choice == 4)
            {
                LoadGoals(goals, ref score);
            }
            else if (choice == 5)
            {
                RecordEvent(goals, ref score);
            }

            Console.WriteLine();
        }
    }

    static int GetLevel(int score)
    {
        return score / 1000 + 1;
    }

    static void CreateGoal(List<Goal> goals)
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        int goalType = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? "";
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine() ?? "0");

        if (goalType == 1)
        {
            goals.Add(new SimpleGoal(name, description, points));
        }
        else if (goalType == 2)
        {
            goals.Add(new EternalGoal(name, description, points));
        }
        else if (goalType == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine() ?? "0");
            goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    static void ListGoals(List<Goal> goals)
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }
    }

    static void SaveGoals(List<Goal> goals, int score)
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine() ?? "";

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(score);

            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    static void LoadGoals(List<Goal> goals, ref int score)
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine() ?? "";

        string[] lines = File.ReadAllLines(fileName);
        goals.Clear();
        score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            string goalType = parts[0];

            if (goalType == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                goal.SetCompleted(bool.Parse(parts[4]));
                goals.Add(goal);
            }
            else if (goalType == "EternalGoal")
            {
                goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (goalType == "ChecklistGoal")
            {
                ChecklistGoal goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                goal.SetAmountCompleted(int.Parse(parts[6]));
                goals.Add(goal);
            }
        }
    }

    static void RecordEvent(List<Goal> goals, ref int score)
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine() ?? "0");

        int pointsEarned = goals[goalNumber - 1].RecordEvent();
        score += pointsEarned;

        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        Console.WriteLine($"You now have {score} points.");
    }
}
