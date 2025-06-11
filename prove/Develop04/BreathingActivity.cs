class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."
    )
    {
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in...");
            PauseWithCountdown(4);
            Console.Write("\nBreathe out...");
            PauseWithCountdown(6);
        }

        DisplayEndingMessage();
    }
}