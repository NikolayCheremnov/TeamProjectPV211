using CarNumberGuideApp.RDB.DbEntities;
using CarNumberGuideApp.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNumberGuideApp.RDB.Repositories
{
    internal class RegionNumberRepository : IRegionNumberRepository
    {
        private readonly AppDbContext _context;

        public RegionNumberRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbRegionNumber CreateRegionNumber(string code, DbRegion region)
        {
            var dbRegionNumber = new DbRegionNumber
            {
                Code = code,
                Region = region
            };

            _context.RegionNumbers.Add(dbRegionNumber);
            _context.SaveChanges();

            return dbRegionNumber;
        }

        public void DeleteRegionNumber(DbRegionNumber dbRegionNumber)
        {
            _context.RegionNumbers.Remove(dbRegionNumber);
            _context.SaveChanges();
        }

        public DbRegionNumber GetById(int id)
        {
            return _context.RegionNumbers.Include(rn => rn.Region).FirstOrDefault(rn => rn.Id == id);
        }

        public DbRegionNumber GetByCode(string code)
        {
            return _context.RegionNumbers.Include(rn => rn.Region).FirstOrDefault(rn => rn.Code == code);
        }

        public void UpdateRegionNumber(DbRegionNumber dbRegionNumber)
        {
            var existingRegionNumber = _context.RegionNumbers.Include(rn => rn.Region).FirstOrDefault(rn => rn.Id == dbRegionNumber.Id);
            if (existingRegionNumber != null)
            {
                existingRegionNumber.Code = dbRegionNumber.Code;
                existingRegionNumber.Region = dbRegionNumber.Region;

                _context.RegionNumbers.Update(existingRegionNumber);
                _context.SaveChanges();
            }
        }
    }
}
