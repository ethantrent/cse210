using System;
using System.Collections.Generic;

public class Job
{
    string _company;
    string _jobTitle;
    int _startYear;
    int _endYear;

// create a constructor
    public Job(string _jobTitle, string _company, int _startYear, int _endYear)
    {
        this._jobTitle = _jobTitle;
        this._company = _company;
        this._startYear = _startYear;
        this._endYear = _endYear;
    }
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}