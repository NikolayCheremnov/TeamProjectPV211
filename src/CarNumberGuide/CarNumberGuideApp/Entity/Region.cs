using System.Collections.Generic;

namespace CarNumberGuideApp.Entity
{
    public class Region
    {
        private string name;
        private HashSet<RegionNumber> regionNumbers;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public HashSet<RegionNumber> RegionNumbers
        {
            get
            {
                return regionNumbers;
            }
            set
            {
                regionNumbers = value;
            }
        }

        public Region()
        {
            name = string.Empty;
            regionNumbers = new HashSet<RegionNumber>();
        }
        public Region(string name)
        {
            this.name = name;
            regionNumbers = new HashSet<RegionNumber>();
        }

        public Region(string name, HashSet<RegionNumber> RegionNumbers)
        {
            this.name = name;
            this.regionNumbers = RegionNumbers;
        }

        public override string ToString()
        {
            string res = "";
            res = string.Join(" ", RegionNumbers);
            return name + " - " + res;
        }
    }
}
