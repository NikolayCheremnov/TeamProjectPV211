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
    public class DbRegion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public  string Name { get; set; }

        public required ICollection<DbRegionNumber> RegionNumbers
        {
            get; set;
        }

        public static Region MapToRegion(DbRegion dbRegion)
        {
            return new Region()
            {
                Name = dbRegion.Name,
                RegionNumbers = dbRegion.RegionNumbers.Select(rn => new RegionNumber
                {
                    Code = rn.Code,
                    Region = new Region(dbRegion.Name) 
                }).ToHashSet()
            };
        }

        public static DbRegion MapToDbRegion(Region region)
        {
            return new DbRegion()
            {
               // Id = id,
                Name = region.Name,
                RegionNumbers = region.RegionNumbers.Select(rn => new DbRegionNumber
                {
                    Code = rn.Code,
                 //   RegionId = id,                  
                }).ToHashSet()
            };
        }
    }
}
