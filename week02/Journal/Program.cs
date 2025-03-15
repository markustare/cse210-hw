using System;

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
            Console.WriteLine("2. Display the contents of the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit program");
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
                    myJournal.SaveToFile();
                    break;
                case "4":
                    myJournal.LoadFromFile();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}