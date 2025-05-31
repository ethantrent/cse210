class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    //Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // split text into words and create Word object
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
            // Word word = new Word(wordText);
            // _words.Add(word);
        }
    }
    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        
        // Get the text for each word and join them back together
        List<string> wordTexts = new List<string>();
        foreach (Word word in _words)
        {
            wordTexts.Add(word.GetDisplayText());
        }
        
        string scriptureText = string.Join(" ", wordTexts);
        
        return $"{referenceText}\n\n{scriptureText}";
    }
    
    public bool HideRandomWords(int count)
    {
        Random random = new Random();
        
        // Get unhidden words
        List<Word> visibleWords = _words.FindAll(word => !word.IsHidden());
        
        // If no visible words remain, all are hidden
        if (visibleWords.Count == 0)
        {
            return true;
        }
        
        // Hide up to 'count' random words
        int wordsToHide = Math.Min(count, visibleWords.Count);
        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex);
        }
        
        // Check if all words are now hidden
        return !_words.Any(word => !word.IsHidden());
    }
}