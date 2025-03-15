using System;

/*
Enhancements:
- Added a "mood" field to each journal entry, allowing users to track emotions.
- Implemented CSV file storage for better compatibility with Excel.
- Ensured CSV format handles commas and quotes correctly.
- Added a summary feature that shows mood trends over multiple entries.
- Allowed users to load and save journal entries as CSV files.
*/

class Program
{
    static void Main()
    {
        Journal myJournal = new Journal();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- Journal Program ---");
            Console.WriteLine("1. Write a new journal entry");
            Console.WriteLine("2. Display the entries in your journal");
            Console.WriteLine("3. Save the journal to a CSV file");
            Console.WriteLine("4. Load the journal from a CSV file");
            Console.WriteLine("5. View summary of moods");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    myJournal.AddEntry();
                    break;
                case "2":
                    myJournal.DisplayJournal();
                    break;
                case "3":
                    myJournal.SaveToCsv();
                    break;
                case "4":
                    myJournal.LoadFromCsv();
                    break;
                case "5":
                    myJournal.DisplaySummary();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
