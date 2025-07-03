namespace FinalProject
{
    public class RecommendationEngine
    {
        public virtual WorkoutPlan RecommendPlan(UserProfile user, ExerciseDatabase db, string splitType = null)
        {
            // Default: fallback to content-based
            var recommender = new ContentBasedRecommender();
            return recommender.RecommendPlan(user, db, splitType);
        }
    }

    public class ContentBasedRecommender : RecommendationEngine
    {
        public override WorkoutPlan RecommendPlan(UserProfile user, ExerciseDatabase db, string splitType = null)
        {
            // Determine plan type based on user's goal
            string goal = user.Goal?.ToLower() ?? "";
            WorkoutPlan plan = null;
            string lastPlanType = user.History?.CompletedPlans?.Count > 0 ?
                user.History.CompletedPlans[^1].GetType().Name.ToLower() : "";

            if (goal.Contains("strength") || goal.Contains("muscle"))
            {
                if (lastPlanType != "strengthplan")
                    plan = new StrengthPlan();
            }
            else if (goal.Contains("cardio") || goal.Contains("weight") || goal.Contains("endurance"))
            {
                if (lastPlanType != "cardioplan")
                    plan = new CardioPlan();
            }
            else if (goal.Contains("flexibility") || goal.Contains("stretch") || goal.Contains("mobility"))
            {
                if (lastPlanType != "flexibilityplan")
                    plan = new FlexibilityPlan();
            }

            // Fallback: rotate plan type if goal is unclear or just did same type
            if (plan == null)
            {
                if (lastPlanType == "strengthplan")
                    plan = new CardioPlan();
                else if (lastPlanType == "cardioplan")
                    plan = new FlexibilityPlan();
                else
                    plan = new StrengthPlan();
            }

            plan.GeneratePlan(db, user, splitType);
            return plan;
        }
    }
} 