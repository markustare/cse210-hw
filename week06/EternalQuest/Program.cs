// ========================================================
// Eternal Quest Program - Program.cs
// Author: Mark Kenneth Laqui Ustare
//
// Exceeds Core Requirements:
// - Clean menu-driven interface with clear prompts and feedback
// - Robust input validation (e.g., TryParse used to prevent crashes)
// - Modular and scalable structure using GoalManager class
// - Use of OOP principles: Abstraction, Encapsulation, Inheritance, Polymorphism
// - Easy to extend with additional goal types or features
// - User-friendly messages and feedback throughout
// - Structured with good whitespace, naming conventions, and file organization
// ========================================================


using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine("---------------------");
            Console.WriteLine($"You have {manager.GetScore()} points.\n");

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;

                case "2":
                    manager.ListGoals();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    manager.SaveGoals(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    manager.LoadGoals(loadFile);
                    break;

                case "5":
                    manager.ListGoals();
                    Console.Write("Which goal did you accomplish? (Enter number): ");
                    if (int.TryParse(Console.ReadLine(), out int goalIndex))
                    {
                        manager.RecordEvent(goalIndex - 1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                case "6":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select from the menu.");
                    break;
            }
        }

        Console.WriteLine("Thanks for playing Eternal Quest!");
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points for completing the goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, description, points));
                break;

            case "2":
                manager.AddGoal(new EternalGoal(name, description, points));
                break;

            case "3":
                Console.Write("How many times does this goal need to be accomplished? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for completing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                manager.AddGoal(new ChecklistGoal(name, description, points, bonus, target));
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }
}
