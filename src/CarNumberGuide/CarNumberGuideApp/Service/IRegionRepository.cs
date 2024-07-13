using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarNumberGuideApp.RDB;
using CarNumberGuideApp.Entity;
using CarNumberGuideApp.RDB.DbEntities;
namespace CarNumberGuideApp.Service
{
    internal interface IRegionRepository
    {
        DbRegion CreateRegion(string name, HashSet<RegionNumber> RegionNumbers);
        DbRegion GetById(int id);
        DbRegion GetByName(string Name);
        void UpdateRegion(DbRegion dbRegion);
        void DeleteRegion(DbRegion dbRegion);
    }
}
