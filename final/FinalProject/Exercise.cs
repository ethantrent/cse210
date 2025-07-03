namespace FinalProject
{
    public class Exercise
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string MuscleGroup { get; set; }
        public string Difficulty { get; set; }
        public string Equipment { get; set; }
        public int Duration { get; set; }
        // New fields for bodybuilding
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int RestTime { get; set; } // in seconds
        public string Tempo { get; set; }
    }

    public class StrengthExercise : Exercise
    {
    }

    public class CardioExercise : Exercise
    {
    }

    public class FlexibilityExercise : Exercise
    {
    }
} 