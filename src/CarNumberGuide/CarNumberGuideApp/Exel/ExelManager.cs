using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarNumberGuideApp.Entity;
using CarNumberGuideApp.Service;
using Microsoft.Graph;
using Spire.Xls;
using IronXL;
using System.Data;

namespace CarNumberGuideApp.Exel
{
    internal class ExelManager : RegionsExporter
    {
        public void Export(List<Region> regions, string path)
        {
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];
            // Сreating the upper part of the table
            worksheet.Range[1, 2].Value = "Название региона";
            worksheet.Range[1, 3].Value = "Список регистрационных номеров";
            // We write down the names of the region and its codes in the cells
            for (int i = 0; i < regions.Count; i++)
            {
                worksheet.Range[i + 2, 2].Value = regions[i].Name;
                StringBuilder stringBuilder = new StringBuilder();
                // With this loop, we read a list of all the numbers to write to one cell
                foreach (var item in regions[i].RegionNumbers)
                {
                    stringBuilder.Append("\t" + item.ToString() + "\t");
                }
                worksheet.Range[i + 2, 3].Value = stringBuilder.ToString();
            }
            // Automatic adjustment of column widths
            worksheet.AllocatedRange.AutoFitColumns();

            // Saving to an Excel file
            workbook.SaveToFile($"{path}.xlsx");
        }
        public List<Region> Import(string path)
        {
            List<Region> regions = new List<Region>();
            Workbook wb = new Workbook();
            // Uploading data
            wb.LoadFromFile(path);
            Worksheet ws = wb.Worksheets[0];
            // Skip the first line
            foreach (var row in ws.Rows.Skip(1))
            {
                // We make an array from a table row
                var dataTableRow = row.ToArray();
                // If there are codes, write down the name of the region and all its codes
                if (dataTableRow[2].Value.Length > 0)
                {
                    HashSet<RegionNumber> regionNumbers = new HashSet<RegionNumber>();
                    var arrayNumbers = dataTableRow[2].Value.ToString().Split(" ").ToArray();
                    foreach(var item in arrayNumbers)
                    {
                        regionNumbers.Add(new RegionNumber(item));
                    }
                    regions.Add(new Region(dataTableRow[1].Value.ToString(), regionNumbers));
                }
                // Or we just write down the name
                else
                {
                    regions.Add(new Region(dataTableRow[1].Value.ToString()));
                }  
            }
            return regions;
        }
    }
}
