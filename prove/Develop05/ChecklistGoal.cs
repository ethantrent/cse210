using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) 
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (!_isCompleted)
        {
            _currentCount++;
            int pointsEarned = _points;
            
            if (_currentCount >= _targetCount)
            {
                _isCompleted = true;
                pointsEarned += _bonusPoints;
            }
            
            return pointsEarned;
        }
        return 0;
    }

    // Method to restore state without affecting score (for loading)
    public void RestoreState(int currentCount)
    {
        _currentCount = currentCount;
        if (_currentCount >= _targetCount)
        {
            _isCompleted = true;
        }
    }

    public override string GetDisplayString()
    {
        string checkbox = _isCompleted ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description}) -- Currently completed: {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name},{_description},{_points},{_targetCount},{_bonusPoints},{_currentCount}";
    }
} 