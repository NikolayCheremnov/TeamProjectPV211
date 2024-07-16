// See https://aka.ms/new-console-template for more information

using CarNumberGuideApp.Exel;
using Spire.Xls;
using System.Drawing;
using System.Linq.Expressions;
namespace CarNumberGuideApp.Entity;

    internal class Program
    { 
        static void Main()
        {
            ExelManager eM = new ExelManager();

            HashSet<RegionNumber> rN = new HashSet<RegionNumber>() {
                new RegionNumber("22"),
                new RegionNumber("122"),
            };

            Region r1 = new Region("Алтайский край", rN);
            Region r2 = new Region("Красноярск");
            Region r3 = new Region("Москва");

            List<Region> lR = new List<Region>();
            lR.Add(r1);
            lR.Add(r2);
            lR.Add(r3);

            eM.Export(lR, "Export");

            List<Region> r = eM.Import("Export.xlsx");
            foreach (Region n in r)
            {
                Console.WriteLine(n);
            }

        }
    }


