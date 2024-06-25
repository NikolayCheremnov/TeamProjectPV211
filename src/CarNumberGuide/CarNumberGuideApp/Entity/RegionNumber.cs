using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarNumberGuideApp.Entity
{
    internal class RegionNumber
    {
        private string regionNumber;
        private Regex regex = new Regex(@"^[0-9]{2,3}$");

        public RegionNumber() { }
        public RegionNumber(string regionNumber) {
            MatchCollection mathes = regex.Matches(regionNumber);
            if (mathes.Count > 0)
            {
                this.regionNumber = regionNumber;
            }
            else
            {
                Console.WriteLine("Вы ввели некорректный номер региона");
            }
        }

        public string GetRegionNumber() => regionNumber;
        public void SetRegionNumber(string regionNumber)
        {
            MatchCollection mathes = regex.Matches(regionNumber);
            if (mathes.Count > 0)
            {
                this.regionNumber = regionNumber;
            }
        }

        public override string ToString() => regionNumber + " RUS";
    }
}
