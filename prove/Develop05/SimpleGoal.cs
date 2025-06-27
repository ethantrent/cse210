using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        if (!_isCompleted)
        {
            _isCompleted = true;
            return _points;
        }
        return 0;
    }
    public void RestoreState(bool isCompleted)
    {
        _isCompleted = isCompleted;
    }

    public override string GetDisplayString()
    {
        string checkbox = _isCompleted ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_name},{_description},{_points},{_isCompleted}";
    }
} 