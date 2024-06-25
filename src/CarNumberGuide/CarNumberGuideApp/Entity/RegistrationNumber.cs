using System;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Class1
/// </summary>
public class RegistrationNumber
{
	private string regNumber;
    private Regex regex = new Regex(@"^[A-Za-z][0-9]{3}[A-Za-z]{2}$");

    public RegistrationNumber() { }
    public RegistrationNumber(string regNumber)	{
        MatchCollection mathes = regex.Matches(regNumber);
        if (mathes.Count > 0)
        {
            this.regNumber = regNumber.ToUpper();
        }
        else {
            Console.WriteLine( $"Номерного знака {regNumber} не существует");
        }
    }

    public string GetRegNumber() => regNumber;
    public void SetRegNumber(string regNumber)
    {
        MatchCollection mathes = regex.Matches(regNumber);
        if (mathes.Count > 0)
        {
            this.regNumber = regNumber.ToUpper();
        }
    }
    public override string ToString() => regNumber;
    
}