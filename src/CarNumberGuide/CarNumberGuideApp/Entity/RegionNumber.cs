namespace CarNumberGuideApp.Entity
{
    public class RegionNumber
    {
        private string code;      
        private Region region;

        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }      
        public Region Region
        {
            get
            {
                return region;
            }
            set
            {
                region = value;
            }
        }

        public RegionNumber() => region = new Region();
        public RegionNumber(string code)
        {
            this.code = code;
            region = new Region();
        }
            public RegionNumber(string code, Region region)
        {
            this.code = code;
            this.region = region;
        }

        public override string ToString() => code + " RUS";

    }
}
