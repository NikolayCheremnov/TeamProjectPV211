using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarNumberGuideApp.Entity;

namespace CarNumberGuideApp.Service
{
    internal interface RegionsExporter
    {
        public void Export(List<Region> regions, string path);
        public List<Region> Import(string path);
    }
}
