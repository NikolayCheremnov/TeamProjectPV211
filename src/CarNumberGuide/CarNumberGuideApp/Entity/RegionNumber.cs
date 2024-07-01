using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarNumberGuideApp.Entity
{
    public class RegionNumber
    {
        //код региона
        private string code;
        //сам регион
        private Region region;

        public string Code { get { return code; } set { code = value; } }        
        public Region Region
        {
            get { return region; }
            set
            {
                region = value;
            }
        }

        public RegionNumber() => region = new Region();
        public RegionNumber(string code) => this.code = code;
        public RegionNumber(string code, Region region)
        {
            this.code = code;
            this.region = region;
        }

        public override string ToString() => code + " RUS";

    }
}
