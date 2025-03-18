using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me."),
            new Scripture(new Reference("2 Nephi", 2, 25), "Adam fell that men might be; and men are, that they might have joy."),
            new Scripture(new Reference("Alma", 37, 6), "By small and simple things are great things brought to pass."),
            new Scripture(new Reference("Moses", 1, 39), "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man."),
            new Scripture(new Reference("Moses", 7, 18), "And the Lord called his people Zion, because they were of one heart and one mind, and dwelt in righteousness; and there was no poor among them."),
            new Scripture(new Reference("Abraham", 3, 22-23), "Now the Lord had shown unto me, Abraham, the intelligences that were organized before the world was; and among all these there were many of the noble and great ones; And God saw these souls that they were good, and he stood in the midst of them, and he said: These I will make my rulers; for he stood among those that were spirits, and he saw that they were good; and he said unto me: Abraham, thou art one of them; thou wast chosen before thou wast born.")
        };

        Random rand = new Random();
        bool keepPlaying = true;

        while (keepPlaying)
        {
            Scripture scripture = scriptures[rand.Next(scriptures.Count)];

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");

                string input = Console.ReadLine();
                if (input.ToLower() == "quit") return;

                scripture.HideRandomWords();

                if (scripture.AllWordsHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("\nAll words are hidden! Well done.");
                    break;
                }
            }

            Console.Write("\nWould you like to memorize another scripture? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            keepPlaying = response == "yes";
        }

        Console.WriteLine("Thank you for practicing scripture memorization!");
    }
}
