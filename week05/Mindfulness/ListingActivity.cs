public class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "What are some of your achievements?",
        "What are things you are grateful for today?"
    };
    private List<string> _unusedPrompts;

    public ListingActivity(Dictionary<string, int> log) : base("Listing", "This activity helps you reflect on good things in your life.", log)
    {
        _unusedPrompts = new List<string>(_prompts);
    }

    public override void Run()
    {
        base.DisplayStartingMessage();
        _log["Listing"]++;

        string prompt = GetNextPrompt();
        Console.WriteLine($"\nList as many responses as you can to the following prompt:\n-- {prompt} --");
        Console.Write("You may begin in: ");
        ShowCountdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");
        base.DisplayEndingMessage();
    }

    private string GetNextPrompt()
    {
        if (_unusedPrompts.Count == 0)
            _unusedPrompts = new List<string>(_prompts);

        int index = _random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);
        return prompt;
    }
}
