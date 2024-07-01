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
        private Regex regex ;

        public RegionNumber() { }
        public RegionNumber(string regionNumber) {
            
            if (СheckingNumberForValidity())
            {
                this.regionNumber = regionNumber;
            }
            else
            {
                throw new ArgumentException("Вы ввели некорректный номер региона");
            }
        }

        public string GetRegionNumber() => regionNumber;
        public void SetRegionNumber(string regionNumber)
        {
            if (СheckingNumberForValidity())
            {
                this.regionNumber = regionNumber;
            }
        }

        public override string ToString() => regionNumber + " RUS";

        private bool СheckingNumberForValidity()
        {
            regex = new Regex(@"^[0-9]{2,3}$");
            MatchCollection mathes = regex.Matches(regionNumber);
            return mathes.Count > 0;
        }
    }
}
