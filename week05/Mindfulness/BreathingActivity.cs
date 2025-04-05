public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(Dictionary<string, int> log) : base("Breathing", "This activity will help you relax through breathing.", log)
    {
    }

    public override void Run()
    {
        base.DisplayStartingMessage();
        _log["Breathing"]++;

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            BreathingAnimation("Breathe in", 4);
            BreathingAnimation("Breathe out", 6);
        }

        base.DisplayEndingMessage();
    }

    private void BreathingAnimation(string action, int seconds)
    {
        for (int i = 1; i <= seconds; i++)
        {
            Console.Clear();
            Console.WriteLine($"{action} {new string('.', i)}");
            Thread.Sleep(1000);
        }
    }
}
