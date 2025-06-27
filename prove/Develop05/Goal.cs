using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isCompleted;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isCompleted = false;
    }

    public string Name { get => _name; }
    public string Description { get => _description; }
    public int Points { get => _points; }
    public bool IsCompleted { get => _isCompleted; }

    public abstract int RecordEvent();
    public abstract string GetDisplayString();
    public abstract string GetStringRepresentation();
} 