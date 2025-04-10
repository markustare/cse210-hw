public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals never complete; just accumulate points
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStatus()
    {
        return $"[∞] {Name} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Description},{Points}";
    }
}
