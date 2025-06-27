public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int Score { get => _score; }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            int pointsEarned = _goals[goalIndex].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
        }
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals have been created yet.");
            return;
        }
        
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayString()}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nYou have {_score} points.");
    }

    public void SaveGoals(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals(string filename)
    {
        try
        {
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                if (lines.Length > 0)
                {
                    if (int.TryParse(lines[0], out int savedScore))
                    {
                        _score = savedScore;
                    }
                    _goals.Clear();

                    for (int i = 1; i < lines.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(lines[i])) continue;
                        
                        string[] parts = lines[i].Split(':');
                        if (parts.Length != 2) continue;
                        
                        string goalType = parts[0];
                        string[] goalData = parts[1].Split(',');

                        switch (goalType)
                        {
                            case "SimpleGoal":
                                if (goalData.Length >= 4)
                                {
                                    var simpleGoal = new SimpleGoal(goalData[0], goalData[1], int.Parse(goalData[2]));
                                    bool isCompleted = bool.Parse(goalData[3]);
                                    simpleGoal.RestoreState(isCompleted);
                                    _goals.Add(simpleGoal);
                                }
                                break;

                            case "EternalGoal":
                                if (goalData.Length >= 3)
                                {
                                    _goals.Add(new EternalGoal(goalData[0], goalData[1], int.Parse(goalData[2])));
                                }
                                break;

                            case "ChecklistGoal":
                                if (goalData.Length >= 6)
                                {
                                    var checklistGoal = new ChecklistGoal(
                                        goalData[0], goalData[1], int.Parse(goalData[2]), 
                                        int.Parse(goalData[3]), int.Parse(goalData[4]));
                                    
                                    // Restore current count without affecting score
                                    int currentCount = int.Parse(goalData[5]);
                                    checklistGoal.RestoreState(currentCount);
                                    _goals.Add(checklistGoal);
                                }
                                break;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

    public int GetGoalCount()
    {
        return _goals.Count;
    }
} 