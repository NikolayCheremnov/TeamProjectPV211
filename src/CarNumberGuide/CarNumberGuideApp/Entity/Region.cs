using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNumberGuideApp.Entity
{
    public class Region
    {
        //имя региона
        private string name;
        //множество кодов региона 2-3 знака
        private HashSet<RegionNumber> regionNumbers;

        public string Name { get { return name; } set { name = value; } }     
        public HashSet<RegionNumber> RegionNumbers { get { return regionNumbers; } set { regionNumbers = value; } }
        

        public Region() { }
        public Region(string name) {
            this.name = name;
        }

        public Region(string name, HashSet<RegionNumber> RegionNumbers)
        {
            this.name = name;
            this.regionNumbers = RegionNumbers;
        }

        public override string ToString() {
            string res = "";
            //берет весь сет и запихивает в одну переменную что бы потом вывести в тустринге
            res = string.Join("", RegionNumbers); 
            return name + " - " + res;
        }

    }
}
