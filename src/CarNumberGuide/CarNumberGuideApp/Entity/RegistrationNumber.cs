using CarNumberGuideApp.Entity;



public class RegistrationNumber
{
    
    private string symbolicCode;
    private RegionNumber regionNumber;

    public string SymbolicCode
    {
        get
        {
            return symbolicCode;
        }
        set
        {
            symbolicCode = value;
        }
    }
    public RegionNumber RegionNumber
    {
        get
        {
            return regionNumber;
        }
        set
        {
            regionNumber = value;
        }
    }

    public RegistrationNumber() => regionNumber = new RegionNumber();
    public RegistrationNumber(string symbolicCode)
    {
        this.symbolicCode = symbolicCode;
        regionNumber = new RegionNumber();
    }

    public RegistrationNumber(string symbolicCode, RegionNumber region)
    {
        this.symbolicCode = symbolicCode;
        this.regionNumber = region;
    }

    public override string ToString() => symbolicCode + RegionNumber.ToString();

}