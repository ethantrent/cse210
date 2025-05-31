class WritingAssignment : Assignment // inherit base class
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic) // base class to inherit
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // call getter since studentName is private
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }
}