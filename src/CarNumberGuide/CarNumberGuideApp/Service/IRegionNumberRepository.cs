using CarNumberGuideApp.RDB.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNumberGuideApp.Service
{
    internal interface IRegionNumberRepository
    {
        DbRegionNumber CreateRegionNumber(string code, DbRegion region);
        DbRegionNumber GetById(int id);
        DbRegionNumber GetByCode(string code);
        void UpdateRegionNumber(DbRegionNumber dbRegionNumber);
        void DeleteRegionNumber(DbRegionNumber dbRegionNumber);
    }

}
