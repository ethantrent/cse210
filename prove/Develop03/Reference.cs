class Reference
{
    // Attributes
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;
    private bool _isSingleVerse;

    // Constructors for verse ranges (put values into attributes)
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _isSingleVerse = true;
    }
    public Reference(string book, int chapter, int start, int end)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = start;
        _endVerse = end;
        _isSingleVerse = false;
    }
    // Methods
    public string GetDisplayText()
    {
        if (_isSingleVerse)
        {
            string text = $"{_book} {_chapter}:{_startVerse}";
            return text;
        }
        else
        {
            string text = $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
            return text;
        }
    }
}