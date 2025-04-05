public class ReflectionActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you overcame a challenge.",
        "Reflect on a moment you showed kindness.",
        "Recall a time when you felt truly at peace.",
        "Think about an experience where you learned something new."
    };
    private List<string> _unusedPrompts;

    public ReflectionActivity(Dictionary<string, int> log) : base("Reflection", "This activity helps you reflect on meaningful moments.", log)
    {
        _unusedPrompts = new List<string>(_prompts);
    }

    public override void Run()
    {
        base.DisplayStartingMessage();
        _log["Reflection"]++;

        string prompt = GetNextPrompt();
        Console.WriteLine($"\nConsider the following prompt:\n-- {prompt} --");
        ShowSpinner(_duration);

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
