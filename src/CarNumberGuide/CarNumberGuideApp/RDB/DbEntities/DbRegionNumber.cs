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
    public class DbRegionNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required string Code { get; set; }

        public int RegionId { get; set; } // Foreign Key
        public  DbRegion Region { get; set; } // Навигационное свойство

        public ICollection<DbRegistrationNumber> RegistrationNumbers { get; set; } = new HashSet<DbRegistrationNumber>();

        public static RegionNumber MapToRegionNumber(DbRegionNumber dbRegionNumber)
        {
            return new RegionNumber()
            {
                Code = dbRegionNumber.Code,
                Region = DbRegion.MapToRegion(dbRegionNumber.Region)// Mapping the Region as well
            };
        }

        public static DbRegionNumber MapToDbRegionNumber(RegionNumber regionNumber, int regionId = 0)
        {
            return new DbRegionNumber()
            {
                Id = regionId,
                Code = regionNumber.Code,
                RegionId = regionNumber.Region != null ? regionId : 0, // Assuming regionId is passed or calculated
                Region = DbRegion.MapToDbRegion(regionNumber.Region) 
            };
        }
    }
}
