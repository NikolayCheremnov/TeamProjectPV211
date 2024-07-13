using CarNumberGuideApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNumberGuideApp.RDB.DbEntities
{
    public class DbRegistrationNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string SymbolicCode { get; set; }
                
        public int RegionNumberId { get; set; } // Foreign Key
        public DbRegionNumber RegionNumber { get; set; } // Навигационное свойство


        public static RegistrationNumber MapToRegistrationNumber(DbRegistrationNumber dbRegistrationNumber)
        {
            return new RegistrationNumber
            {
                SymbolicCode = dbRegistrationNumber.SymbolicCode,
                RegionNumber = DbRegionNumber.MapToRegionNumber(dbRegistrationNumber.RegionNumber)
            };
        }
        public static DbRegistrationNumber MapToDbRegistrationNumber(RegistrationNumber registrationNumber)
        {
            return new DbRegistrationNumber
            {
                SymbolicCode = registrationNumber.SymbolicCode,
                RegionNumber = DbRegionNumber.MapToDbRegionNumber(registrationNumber.RegionNumber)
            };
        }
    }
}
