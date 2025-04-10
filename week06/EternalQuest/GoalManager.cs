using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            var goal = _goals[goalIndex];
            goal.RecordEvent();
            _score += goal.Points;

            if (goal is ChecklistGoal checklist && checklist.IsComplete())
            {
                _score += checklist.GetBonus();
            }
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals successfully saved.");
    }

    public void LoadGoals(string filename)
    {
        _goals.Clear();

        try
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] values = parts[1].Split(',');

                switch (type)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(values[0], values[1], int.Parse(values[2]))
                        {
                            // Load completion status if needed
                        });
                        if (bool.Parse(values[3])) _goals[^1].RecordEvent();
                        break;

                    case "EternalGoal":
                        _goals.Add(new EternalGoal(values[0], values[1], int.Parse(values[2])));
                        break;

                    case "ChecklistGoal":
                        ChecklistGoal checklist = new ChecklistGoal(values[0], values[1], int.Parse(values[2]), int.Parse(values[4]), int.Parse(values[3]));
                        for (int j = 0; j < int.Parse(values[5]); j++)
                        {
                            checklist.RecordEvent(); // simulate previous completions
                        }
                        _goals.Add(checklist);
                        break;
                }
            }

            Console.WriteLine("Goals successfully loaded.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading file: {e.Message}");
        }
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetGoalCount()
    {
        return _goals.Count;
    }

    public Goal GetGoal(int index)
    {
        return _goals[index];
    }
}
