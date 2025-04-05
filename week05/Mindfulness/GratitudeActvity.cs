public class GratitudeActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Think of something kind someone did for you today.",
        "Reflect on a moment that made you smile this week.",
        "What is something simple that brings you joy?",
        "Who is someone in your life you’re grateful for?"
    };
    private List<string> _unusedPrompts;

    public GratitudeActivity(Dictionary<string, int> log) : base("Gratitude", "This activity helps you cultivate gratitude.", log)
    {
        _unusedPrompts = new List<string>(_prompts);
    }

    public override void Run()
    {
        base.DisplayStartingMessage();
        _log["Gratitude"]++;

        string prompt = GetNextPrompt();
        Console.WriteLine($"\nTake a moment to reflect on the following:\n-- {prompt} --");
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
