using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNumberGuideApp.Entity
{
    internal class RegionName
    {
        public HashSet <RegionNumber> RegionNumber { get; set; }
        public RegistrationNumber RegistrationNumber { get; set; }
        public RegionName() { }
        public RegionName(RegistrationNumber RegistrationNumber, RegionNumber RegionNumber) {
            this.RegistrationNumber = RegistrationNumber;
            this.RegionNumber.Add(RegionNumber);
        }
    }
}
