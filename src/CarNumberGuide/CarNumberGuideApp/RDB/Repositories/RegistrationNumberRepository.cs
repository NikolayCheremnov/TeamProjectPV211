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
    internal class RegistrationNumberRepository : IRegistrationNumberRepository
    {
        private readonly AppDbContext _context;

        public RegistrationNumberRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbRegistrationNumber CreateRegistrationNumber(string symbolicCode, DbRegionNumber regionNumber)
        {
            var dbRegistrationNumber = new DbRegistrationNumber
            {
                SymbolicCode = symbolicCode,
                RegionNumber = regionNumber
            };

            _context.RegistrationNumbers.Add(dbRegistrationNumber);
            _context.SaveChanges();

            return dbRegistrationNumber;
        }

        public void DeleteRegistrationNumber(DbRegistrationNumber dbRegistrationNumber)
        {
            _context.RegistrationNumbers.Remove(dbRegistrationNumber);
            _context.SaveChanges();
        }

        public DbRegistrationNumber GetById(int id)
        {
            return _context.RegistrationNumbers.Include(rn => rn.RegionNumber).FirstOrDefault(rn => rn.Id == id);
        }

        public DbRegistrationNumber GetBySymbolicCode(string symbolicCode)
        {
            return _context.RegistrationNumbers.Include(rn => rn.RegionNumber).FirstOrDefault(rn => rn.SymbolicCode == symbolicCode);
        }

        public void UpdateRegistrationNumber(DbRegistrationNumber dbRegistrationNumber)
        {
            var existingRegistrationNumber = _context.RegistrationNumbers.Include(rn => rn.RegionNumber).FirstOrDefault(rn => rn.Id == dbRegistrationNumber.Id);
            if (existingRegistrationNumber != null)
            {
                existingRegistrationNumber.SymbolicCode = dbRegistrationNumber.SymbolicCode;
                existingRegistrationNumber.RegionNumber = dbRegistrationNumber.RegionNumber;

                _context.RegistrationNumbers.Update(existingRegistrationNumber);
                _context.SaveChanges();
            }
        }
    }
}
