using CarNumberGuideApp.RDB.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNumberGuideApp.Service
{
    internal interface IRegistrationNumberRepository
    {
        DbRegistrationNumber CreateRegistrationNumber(string symbolicCode, DbRegionNumber regionNumber);
        DbRegistrationNumber GetById(int id);
        DbRegistrationNumber GetBySymbolicCode(string symbolicCode);
        void UpdateRegistrationNumber(DbRegistrationNumber dbRegistrationNumber);
        void DeleteRegistrationNumber(DbRegistrationNumber dbRegistrationNumber);
    }

}
