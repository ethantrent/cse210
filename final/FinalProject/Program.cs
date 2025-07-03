using System;
using System.Collections.Generic;
using FinalProject;

class Program
{
    static void Main(string[] args)
    {
        var db = new ExerciseDatabase();
        db.LoadExercises("exercises.json");
        Console.WriteLine($"Loaded {db.Exercises.Count} exercises.\n");

        // Collect user profile details
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.Write("Enter your age: ");
        int age = int.TryParse(Console.ReadLine(), out int a) ? a : 0;
        Console.Write("Enter your gender: ");
        string gender = Console.ReadLine();
        Console.Write("Enter your fitness level (Beginner/Intermediate/Advanced): ");
        string fitnessLevel = Console.ReadLine();
        Console.Write("Enter your experience level (Beginner/Intermediate/Advanced): ");
        string experienceLevel = Console.ReadLine();
        Console.Write("Enter your weight (kg): ");
        double weight = double.TryParse(Console.ReadLine(), out double w) ? w : 0.0;
        Console.Write("Enter your body fat percentage: ");
        double bodyFat = double.TryParse(Console.ReadLine(), out double bf) ? bf : 0.0;
        Console.Write("Enter your preferred training split (e.g., Push/Pull/Legs, Upper/Lower, Full Body): ");
        string split = Console.ReadLine();
        Console.Write("Enter your main goal (e.g., Build Muscle, Lose Fat, Strength Gain, Hypertrophy, Cutting, Bulking): ");
        string goal = Console.ReadLine();
        Console.Write("Enter your specific goal (e.g., Bench 100kg, 10% body fat): ");
        string specificGoal = Console.ReadLine();
        Console.Write("List your available equipment (comma separated): ");
        var equipment = new List<string>(Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));

        var user = new UserProfile
        {
            Name = name,
            Age = age,
            Gender = gender,
            FitnessLevel = fitnessLevel,
            ExperienceLevel = experienceLevel,
            Weight = weight,
            BodyFatPercentage = bodyFat,
            PreferredSplit = split,
            Goal = goal,
            SpecificGoal = specificGoal,
            Equipment = equipment,
            History = new WorkoutHistory()
        };
        Console.WriteLine($"\nWelcome, {user.Name}!\nYour goal: {user.Goal}\nFitness level: {user.FitnessLevel}\nExperience level: {user.ExperienceLevel}\nWeight: {user.Weight} kg\nBody Fat: {user.BodyFatPercentage}%\nPreferred Split: {user.PreferredSplit}\nSpecific Goal: {user.SpecificGoal}\n");

        // Ask if user wants to use a different split for this session
        Console.Write($"Enter split for today's workout (press Enter to use your preferred split: {user.PreferredSplit}): ");
        string sessionSplit = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(sessionSplit))
            sessionSplit = user.PreferredSplit;

        // 3. Recommend a plan
        var recommender = new ContentBasedRecommender();
        var plan = recommender.RecommendPlan(user, db, sessionSplit);
        Console.WriteLine($"Recommended Plan: {plan.Name} ({plan.Difficulty})");
        Console.WriteLine($"Split: {plan.SplitType}");
        Console.WriteLine($"Exercises:");
        foreach (var ex in plan.Exercises)
        {
            Console.WriteLine($"- {ex.Name} ({ex.MuscleGroup}, {ex.Equipment})");
            Console.WriteLine($"  Sets: {ex.Sets}, Reps: {ex.Reps}, Rest: {ex.RestTime}s, Tempo: {ex.Tempo}");
        }
        Console.WriteLine($"Total Duration: {plan.Duration} min\n");

        // 4. Mark plan as complete
        Console.WriteLine("Marking plan as complete...");
        user.History.MarkPlanComplete(plan);

        // 5. Show progress
        Console.WriteLine($"\nYour Progress: {user.History.GetProgress()}\n");

        // 6. (Optional) Recommend another plan to see rotation
        Console.WriteLine("Recommending another plan...");
        var nextPlan = recommender.RecommendPlan(user, db, sessionSplit);
        Console.WriteLine($"Next Recommended Plan: {nextPlan.Name} ({nextPlan.Difficulty})");
        Console.WriteLine($"Split: {nextPlan.SplitType}");
        foreach (var ex in nextPlan.Exercises)
        {
            Console.WriteLine($"- {ex.Name} ({ex.MuscleGroup}, {ex.Equipment})");
            Console.WriteLine($"  Sets: {ex.Sets}, Reps: {ex.Reps}, Rest: {ex.RestTime}s, Tempo: {ex.Tempo}");
        }
        Console.WriteLine($"Total Duration: {nextPlan.Duration} min\n");
    }
}