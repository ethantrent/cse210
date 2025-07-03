using System.Collections.Generic;
using FinalProject;

namespace FinalProject
{
    public class PlanManager
    {
        public List<WorkoutPlan> Plans { get; set; }

        public PlanManager()
        {
            Plans = new List<WorkoutPlan>();
        }

        public void CreatePlan(WorkoutPlan plan)
        {
            Plans.Add(plan);
        }

        public WorkoutPlan GetPlan(string name)
        {
            return Plans.Find(p => p.Name == name);
        }
    }
} 