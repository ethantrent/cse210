using System.Collections.Generic;
using FinalProject;
using System;

namespace FinalProject
{
    public class CompletedExercise
    {
        public string Name { get; set; }
        public string MuscleGroup { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int RestTime { get; set; }
        public string Tempo { get; set; }
        public DateTime DateCompleted { get; set; }
    }

    public class CompletedPlan
    {
        public string PlanName { get; set; }
        public string SplitType { get; set; }
        public List<CompletedExercise> Exercises { get; set; }
        public DateTime DateCompleted { get; set; }
    }

    public class WorkoutHistory
    {
        public List<WorkoutPlan> CompletedPlans { get; set; }
        public List<CompletedPlan> CompletedPlanDetails { get; set; }
        public string Progress { get; set; }
        public int TotalCompleted { get; set; }
        public int CurrentStreak { get; set; }
        public DateTime? LastCompletedDate { get; set; }

        public WorkoutHistory()
        {
            CompletedPlans = new List<WorkoutPlan>();
            CompletedPlanDetails = new List<CompletedPlan>();
            Progress = string.Empty;
            TotalCompleted = 0;
            CurrentStreak = 0;
            LastCompletedDate = null;
        }

        public void AddPlan(WorkoutPlan plan)
        {
            CompletedPlans.Add(plan);
            AddCompletedPlanDetails(plan);
            UpdateProgress();
        }

        public void MarkPlanComplete(WorkoutPlan plan)
        {
            AddPlan(plan);
        }

        private void AddCompletedPlanDetails(WorkoutPlan plan)
        {
            var completedExercises = new List<CompletedExercise>();
            foreach (var ex in plan.Exercises)
            {
                completedExercises.Add(new CompletedExercise
                {
                    Name = ex.Name,
                    MuscleGroup = ex.MuscleGroup,
                    Sets = ex.Sets,
                    Reps = ex.Reps,
                    RestTime = ex.RestTime,
                    Tempo = ex.Tempo,
                    DateCompleted = DateTime.Now
                });
            }
            CompletedPlanDetails.Add(new CompletedPlan
            {
                PlanName = plan.Name,
                SplitType = plan.SplitType,
                Exercises = completedExercises,
                DateCompleted = DateTime.Now
            });
        }

        private void UpdateProgress()
        {
            TotalCompleted = CompletedPlans.Count;
            // Streak logic: increment if last completed was yesterday, reset if missed a day
            if (CompletedPlans.Count > 0)
            {
                var today = DateTime.Today;
                if (LastCompletedDate.HasValue)
                {
                    if ((today - LastCompletedDate.Value.Date).Days == 1)
                        CurrentStreak++;
                    else if ((today - LastCompletedDate.Value.Date).Days > 1)
                        CurrentStreak = 1;
                }
                else
                {
                    CurrentStreak = 1;
                }
                LastCompletedDate = today;
            }
            Progress = $"Total completed: {TotalCompleted}, Current streak: {CurrentStreak} days";
        }

        public string GetProgress() => Progress;
    }
} 