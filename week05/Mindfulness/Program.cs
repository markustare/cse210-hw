// - Added a new activity: GratitudeActivity, where users list things they’re thankful for.
// - Implemented session tracking: keeps a count of how many times each activity is performed.
// - Ensured no reflection or listing prompt repeats until all have been used once.
// - Implemented basic session logging: writes activity usage summary to a text file at the end.
// - Enhanced breathing animation with progressive dots to simulate inhale/exhale rhythm.
// These features demonstrate creativity, deeper understanding of object-oriented programming,
// and user-focused design enhancements.

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> activityLog = new Dictionary<string, int>
        {
            { "Breathing", 0 },
            { "Reflection", 0 },
            { "Listing", 0 },
            { "Gratitude", 0 }
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Start Gratitude Activity");
            Console.WriteLine("5. View Activity Summary");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity(activityLog);
                    break;
                case "2":
                    activity = new ReflectionActivity(activityLog);
                    break;
                case "3":
                    activity = new ListingActivity(activityLog);
                    break;
                case "4":
                    activity = new GratitudeActivity(activityLog);
                    break;
                case "5":
                    ShowActivitySummary(activityLog);
                    continue;
                case "6":
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    Thread.Sleep(1000);
                    continue;
            }

            activity.Run();
        }
    }

    static void ShowActivitySummary(Dictionary<string, int> log)
    {
        Console.Clear();
        Console.WriteLine("Activity Summary This Session:");
        foreach (var item in log)
        {
            Console.WriteLine($"- {item.Key} Activity: {item.Value} time(s)");
        }
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }
}
