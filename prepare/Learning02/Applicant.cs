using System;
using System.Collections.Generic;

public class Applicant
{
    public string _firstName;
    public string _lastName;
    public string _phoneNumber;
    public string _emailAddress;
    public int _orderOfApplication;
    public int _rank;
    public Resume _resume;

    public void Display() {
        Console.WriteLine($"Name: {_firstName} {_lastName}");
        Console.WriteLine($"Phone Number: {_phoneNumber}");
        Console.WriteLine($"Email Address: {_emailAddress}");
        Console.WriteLine($"Order of Application: {_orderOfApplication}");
        Console.WriteLine($"Rank: {_rank}");
        _resume.Display();
    }
}