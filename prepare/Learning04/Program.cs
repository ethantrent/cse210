class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new("Ethan Trent", "Object-Oriented Programming");
        Console.WriteLine(assignment.GetSummary());

        MathAssignment mathAssignment = new("The Jakes", "Neuroscience", "7.2", "1-5000");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        WritingAssignment writingAssignment = new("Erika Trent", "Biography", "My Book");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());


    }
}