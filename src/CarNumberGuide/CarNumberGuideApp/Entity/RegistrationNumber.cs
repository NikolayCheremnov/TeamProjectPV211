using System;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Class1
/// </summary>
public class RegistrationNumber
{
	private string regNumber;
    public string RegNumber
    {
        get
        {
            return regNumber;
        }
        set
        {
            MatchCollection mathes = regex.Matches(value);
            if (mathes.Count > 0)
            {
                this.regNumber = regNumber.ToUpper();
            }
        }
    }
    private Regex regex = new Regex(@"^[A-Za-z][0-9]{3}[A-Za-z]{2}$");

    public RegistrationNumber() { }
    public RegistrationNumber(string regNumber)	{        
        if (СheckingNumberForValidity())
        {
            this.regNumber = regNumber.ToUpper();
        }
        else {
            throw new ArgumentException( $"Номерного знака {regNumber} не существует");
        }
    }

    public override string ToString() => regNumber;

    private bool СheckingNumberForValidity(string regNumber)
    {
        regex = new Regex(@"^[0-9]{2,3}$");
        MatchCollection mathes = regex.Matches(regNumber);
        return mathes.Count > 0;
    }

}