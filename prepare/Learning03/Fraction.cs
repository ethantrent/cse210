public class Fraction
{
    // Attributes
    private int _numerator;
    private int _denominator;

    // Constructors
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int wholeNumber)
    {
        _numerator = wholeNumber;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    // Getter and Setter
    public int Top
    {
        get { return _numerator; }
        set { _numerator = value; }
    }

    public int Bottom
    {
        get { return _denominator; }
        set { _denominator = value; }
    }

    // Get Fraction and Decimal
    public string GetFractionString()
    {
        string text = $"{_numerator}/{_denominator}";
        return text;
    }

    public double GetDecimalValue()
    {
        double value = (double)_numerator / _denominator;
        return value;
    }
}