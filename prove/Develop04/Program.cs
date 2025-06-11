class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            Activity activity = null;
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    activity = new BreathingActivity();
                    break;
                case "2":
                    Console.Clear();
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    Console.Clear();
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to continue...");
                    Console.ReadLine();
                    continue;
            }

            activity.RunActivity();
        }
    }
}