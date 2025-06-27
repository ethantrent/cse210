// Creative Features and Exceeding Requirements:
// - Added motivational messages after recording a goal event to encourage the user.
// - Implemented an achievement system that unlocks achievements based on the user's score.
// - Included a level display that shows the user's current level and points needed for the next level.
// - Added a "Goal of the Day" feature to inspire daily focus.

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        string filename = "goals.txt";
        
        // Load existing goals if available
        goalManager.LoadGoals(filename);

        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("\n=== ETERNAL QUEST ===");
            goalManager.DisplayScore();
            DisplayLevel(goalManager.Score);
            DisplayAchievements(goalManager.Score);
            
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Goal of the Day");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    CreateNewGoal(goalManager);
                    break;
                case "2":
                    goalManager.DisplayGoals();
                    break;
                case "3":
                    goalManager.SaveGoals(filename);
                    Console.WriteLine("Goals saved successfully!");
                    break;
                case "4":
                    goalManager.LoadGoals(filename);
                    Console.WriteLine("Goals loaded successfully!");
                    break;
                case "5":
                    RecordEvent(goalManager);
                    break;
                case "6":
                    ShowGoalOfTheDay(goalManager);
                    break;
                case "7":
                    quit = true;
                    Console.WriteLine("Goodbye! Keep up the great work on your eternal quest!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static void CreateNewGoal(GoalManager goalManager)
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        
        string goalType = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(goalType) || (goalType != "1" && goalType != "2" && goalType != "3"))
        {
            Console.WriteLine("Invalid goal type. Please enter 1, 2, or 3.");
            return;
        }
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Goal name cannot be empty.");
            return;
        }
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Goal description cannot be empty.");
            return;
        }
        
        Console.Write("What is the amount of points associated with this goal? ");
        if (!int.TryParse(Console.ReadLine(), out int points) || points <= 0)
        {
            Console.WriteLine("Please enter a valid positive number for points.");
            return;
        }
        
        Goal goal = null;
        
        switch (goalType)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;
            case "2":
                goal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                if (!int.TryParse(Console.ReadLine(), out int targetCount) || targetCount <= 0)
                {
                    Console.WriteLine("Please enter a valid positive number for target count.");
                    return;
                }
                
                Console.Write("What is the bonus for accomplishing it that many times? ");
                if (!int.TryParse(Console.ReadLine(), out int bonusPoints) || bonusPoints < 0)
                {
                    Console.WriteLine("Please enter a valid non-negative number for bonus points.");
                    return;
                }
                
                goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                break;
        }
        
        goalManager.AddGoal(goal);
        Console.WriteLine("Goal created successfully!");
    }

    static void RecordEvent(GoalManager goalManager)
    {
        if (goalManager.GetGoalCount() == 0)
        {
            Console.WriteLine("No goals available. Please create a goal first.");
            return;
        }
        
        goalManager.DisplayGoals();
        Console.Write("Which goal did you accomplish? ");
        
        if (!int.TryParse(Console.ReadLine(), out int goalNumber) || goalNumber <= 0)
        {
            Console.WriteLine("Please enter a valid goal number.");
            return;
        }
        
        int goalIndex = goalNumber - 1;
        
        if (goalIndex >= 0 && goalIndex < goalManager.GetGoalCount())
        {
            goalManager.RecordEvent(goalIndex);
            ShowMotivationalMessage();
        }
        else
        {
            Console.WriteLine($"Invalid goal number. Please enter a number between 1 and {goalManager.GetGoalCount()}.");
        }
    }

    static void ShowGoalOfTheDay(GoalManager goalManager)
    {
        if (goalManager.GetGoalCount() == 0)
        {
            Console.WriteLine("No goals available. Please create a goal first.");
            return;
        }
        
        Console.WriteLine("\n🎯 GOAL OF THE DAY 🎯");
        Console.WriteLine("Today's focus: Complete one of your incomplete goals!");
        Console.WriteLine("You can do it! Every small step brings you closer to your eternal quest.");
    }

    static void DisplayLevel(int score)
    {
        int level = (score / 1000) + 1;
        Console.WriteLine($"Level: {level} | Points to next level: {1000 - (score % 1000)}");
    }

    static void DisplayAchievements(int score)
    {
        if (score >= 100 && score < 500)
            Console.WriteLine("🏆 Achievement Unlocked: Beginner's Spirit!");
        else if (score >= 500 && score < 1000)
            Console.WriteLine("🏆 Achievement Unlocked: Dedicated Disciple!");
        else if (score >= 1000 && score < 2000)
            Console.WriteLine("🏆 Achievement Unlocked: Faithful Servant!");
        else if (score >= 2000)
            Console.WriteLine("🏆 Achievement Unlocked: Eternal Champion!");
    }

    static void ShowMotivationalMessage()
    {
        string[] messages = {
            "🌟 Amazing work! You're making great progress on your eternal quest!",
            "✨ Every goal completed brings you closer to your divine potential!",
            "💪 You're building spiritual strength one goal at a time!",
            "🙏 Heavenly Father is pleased with your efforts!",
            "🎉 Keep up the fantastic work! You're on the right path!"
        };
        
        Random random = new Random();
        Console.WriteLine(messages[random.Next(messages.Length)]);
    }
}