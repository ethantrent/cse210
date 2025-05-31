class MathAssignment : Assignment // inherit base class
{
    // attributes
    private string _textbookSection;
    private string _problems;

    // constructor
    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic) // base class to inherit
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}