class Assignment
{
    // attributes
    private string _studentName;
    private string _topic;

    // constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // getters
    public string GetStudentName()
    {
        return _studentName;
    }

    public string getTopic()
    {
        return _topic;
    }
    // method
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}