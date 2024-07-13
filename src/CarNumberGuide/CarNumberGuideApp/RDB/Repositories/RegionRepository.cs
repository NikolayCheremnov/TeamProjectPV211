using CarNumberGuideApp.Entity;
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
    internal class RegionRepository : IRegionRepository
    {
        private readonly AppDbContext _context;

        public RegionRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbRegion CreateRegion(string name, HashSet<RegionNumber> regionNumbers)
        {
            var dbRegion = new DbRegion
            {
                Name = name,
                RegionNumbers = regionNumbers.Select(rn => DbRegionNumber.MapToDbRegionNumber(rn)).ToList()
            };

            _context.Regions.Add(dbRegion);
            _context.SaveChanges();

            return dbRegion;
        }

        public void DeleteRegion(DbRegion dbRegion)
        {
            try
            {
                _context.Regions.Remove(dbRegion);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении региона: {ex.Message}");
                throw; // выбрасывает исключение для дальнейшей обработки
            }
        }

        public DbRegion GetByName(string name)
        {
            return _context.Regions.FirstOrDefault(x => x.Name == name);
        }

        public DbRegion GetById(int id)
        {
            return _context.Regions.Find(id);
        }

        public void UpdateRegion(DbRegion dbRegion)
        {
            var existingRegion = _context.Regions.Include(r => r.RegionNumbers).FirstOrDefault(r => r.Id == dbRegion.Id);
            if (existingRegion != null)
            {
                existingRegion.Name = dbRegion.Name;
                existingRegion.RegionNumbers = dbRegion.RegionNumbers;

                _context.Regions.Update(existingRegion);
                _context.SaveChanges();
            }
        }
    }

}
