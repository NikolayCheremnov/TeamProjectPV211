using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNumberGuideApp.Entity
{
    internal class Region
    {
        public string Name { get;set }
        public HashSet <RegionNumber> RegionNumber { get; set; }
        public RegistrationNumber RegistrationNumber { get; set; }

        public Region() { }
        public Region(RegistrationNumber RegistrationNumber, RegionNumber RegionNumber) {
            this.RegistrationNumber = RegistrationNumber;
            this.RegionNumber.Add(RegionNumber);
        }
    }
}
