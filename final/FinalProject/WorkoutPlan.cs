using System.Collections.Generic;
using FinalProject;
using System.Linq;

namespace FinalProject
{
    public class WorkoutPlan
    {
        public string Name { get; set; }
        public List<Exercise> Exercises { get; set; }
        public int Duration { get; set; }
        public string Difficulty { get; set; }
        public string SplitType { get; set; }

        public WorkoutPlan()
        {
            Exercises = new List<Exercise>();
        }

        public virtual void GeneratePlan(ExerciseDatabase db, UserProfile user, string splitType = null) { /* To be overridden */ }

        public static List<string> GetMuscleGroupsForSplit(string splitType)
        {
            switch (splitType?.ToLower())
            {
                case "push":
                    return new List<string> { "Chest", "Shoulders", "Triceps" };
                case "pull":
                    return new List<string> { "Back", "Biceps" };
                case "legs":
                    return new List<string> { "Legs", "Calves", "Glutes" };
                case "upper":
                    return new List<string> { "Chest", "Back", "Shoulders", "Biceps", "Triceps" };
                case "lower":
                    return new List<string> { "Legs", "Calves", "Glutes" };
                case "full body":
                default:
                    return new List<string> { "Chest", "Back", "Shoulders", "Biceps", "Triceps", "Legs", "Calves", "Glutes" };
            }
        }

        public static void ApplyProgressiveOverload(Exercise ex, UserProfile user)
        {
            var history = user.History?.CompletedPlanDetails;
            if (history == null || history.Count == 0) return;
            var prev = history
                .SelectMany(p => p.Exercises)
                .Where(e => e.Name == ex.Name)
                .OrderByDescending(e => e.DateCompleted)
                .FirstOrDefault();
            if (prev != null)
            {
                if (ex.Sets < 8) ex.Sets = prev.Sets + 1;
                if (ex.Reps < 20) ex.Reps = prev.Reps + 1;
            }
        }
    }

    public class StrengthPlan : WorkoutPlan
    {
        public override void GeneratePlan(ExerciseDatabase db, UserProfile user, string splitType = null)
        {
            Name = "Strength Plan";
            Difficulty = user.FitnessLevel;
            SplitType = splitType ?? user.PreferredSplit;
            int numExercises = user.FitnessLevel.ToLower() switch
            {
                "beginner" => 4,
                "intermediate" => 6,
                "advanced" => 8,
                _ => 5
            };
            var muscleGroups = GetMuscleGroupsForSplit(SplitType);
            var availableExercises = db.Exercises
                .Where(e => e.Type.ToLower() == "strength" &&
                            muscleGroups.Contains(e.MuscleGroup, System.StringComparer.OrdinalIgnoreCase) &&
                            (user.Equipment.Contains(e.Equipment) || e.Equipment.ToLower() == "none"))
                .ToList();
            var rnd = new System.Random();
            Exercises = availableExercises.OrderBy(x => rnd.Next()).Take(numExercises).ToList();
            foreach (var ex in Exercises)
            {
                ApplyProgressiveOverload(ex, user);
            }
            Duration = Exercises.Count * 5;
        }
    }

    public class CardioPlan : WorkoutPlan
    {
        public override void GeneratePlan(ExerciseDatabase db, UserProfile user, string splitType = null)
        {
            Name = "Cardio Plan";
            Difficulty = user.FitnessLevel;
            SplitType = splitType ?? user.PreferredSplit;
            int numExercises = user.FitnessLevel.ToLower() switch
            {
                "beginner" => 3,
                "intermediate" => 5,
                "advanced" => 7,
                _ => 4
            };
            var muscleGroups = GetMuscleGroupsForSplit(SplitType);
            var availableExercises = db.Exercises
                .Where(e => e.Type.ToLower() == "cardio" &&
                            muscleGroups.Contains(e.MuscleGroup, System.StringComparer.OrdinalIgnoreCase) &&
                            (user.Equipment.Contains(e.Equipment) || e.Equipment.ToLower() == "none"))
                .ToList();
            var rnd = new System.Random();
            Exercises = availableExercises.OrderBy(x => rnd.Next()).Take(numExercises).ToList();
            foreach (var ex in Exercises)
            {
                ApplyProgressiveOverload(ex, user);
            }
            Duration = Exercises.Count * 5;
        }
    }

    public class FlexibilityPlan : WorkoutPlan
    {
        public override void GeneratePlan(ExerciseDatabase db, UserProfile user, string splitType = null)
        {
            Name = "Flexibility Plan";
            Difficulty = user.FitnessLevel;
            SplitType = splitType ?? user.PreferredSplit;
            int numExercises = user.FitnessLevel.ToLower() switch
            {
                "beginner" => 3,
                "intermediate" => 5,
                "advanced" => 7,
                _ => 4
            };
            var muscleGroups = GetMuscleGroupsForSplit(SplitType);
            var availableExercises = db.Exercises
                .Where(e => e.Type.ToLower() == "flexibility" &&
                            muscleGroups.Contains(e.MuscleGroup, System.StringComparer.OrdinalIgnoreCase) &&
                            (user.Equipment.Contains(e.Equipment) || e.Equipment.ToLower() == "none"))
                .ToList();
            var rnd = new System.Random();
            Exercises = availableExercises.OrderBy(x => rnd.Next()).Take(numExercises).ToList();
            foreach (var ex in Exercises)
            {
                ApplyProgressiveOverload(ex, user);
            }
            Duration = Exercises.Count * 5;
        }
    }
} 