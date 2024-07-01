using CarNumberGuideApp.Entity;
using System;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Class1
/// </summary>
public class RegistrationNumber
{
    //6символьный код
    private string symbolicCode;
    private RegionNumber regionNumber;

    public string SymbolicCode { get { return symbolicCode; } set { symbolicCode = value; } }    
    public RegionNumber RegionNumber
    {
        get
        {
            if (regionNumber == null)
            {
                regionNumber = new RegionNumber();

            }
            return regionNumber;
        }
        set { regionNumber = value; }
    }

    public RegistrationNumber() { }
    public RegistrationNumber(string symbolicCode)
    {
        this.symbolicCode = symbolicCode;
    }

    public RegistrationNumber(string symbolicCode, RegionNumber region)
    {
        this.symbolicCode = symbolicCode;
        this.regionNumber = region;
    }


    public override string ToString() => symbolicCode + RegionNumber.ToString();

}