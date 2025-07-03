using System.Collections.Generic;
using FinalProject;

namespace FinalProject
{
    public class UserProfile
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string FitnessLevel { get; set; }
        public string Goal { get; set; }
        public List<string> Equipment { get; set; }
        public WorkoutHistory History { get; set; }
        public PlanManager PlanManager { get; set; }

        // New fields for serious fitness users
        public string ExperienceLevel { get; set; }
        public double Weight { get; set; }
        public double BodyFatPercentage { get; set; }
        public string PreferredSplit { get; set; }
        public string SpecificGoal { get; set; }

        public UserProfile()
        {
            Equipment = new List<string>();
            History = new WorkoutHistory();
            PlanManager = new PlanManager();
            ExperienceLevel = "Beginner";
            Weight = 0.0;
            BodyFatPercentage = 0.0;
            PreferredSplit = "Full Body";
            SpecificGoal = string.Empty;
        }

        public void UpdateProfile() { /* TODO: Implement */ }
        public WorkoutHistory GetHistory() => History;
    }
} 