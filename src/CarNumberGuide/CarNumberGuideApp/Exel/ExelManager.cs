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
    internal class ExelManager : ExportImportRegionsAuto
    {
        public void Export(List<Region> regions, string path)
        {
            //Создание объекта Workbook 
            Workbook workbook = new Workbook();

            //Получение первой рабочей страницы
            Worksheet worksheet = workbook.Worksheets[0];

            worksheet.Range[1, 2].Value = "Название региона";
            worksheet.Range[1, 3].Value = "Список регистрационных номеров";
            // Записываем названия региона и его коды в ячейки
            for (int i = 0; i < regions.Count; i++)
            {
                worksheet.Range[i + 2, 2].Value = regions[i].Name;
                string str = "";
                foreach(var j in regions[i].RegionNumbers)
                {
                    str += j.ToString() + "\t";
                }
                worksheet.Range[i + 2, 3].Value = str;
            }

            //Автоматическое подгонка ширины столбцов
            worksheet.AllocatedRange.AutoFitColumns();

            //Сохранение в файл Excel
            workbook.SaveToFile($"{path}.xlsx");
        }
        public List<Region> Import(string path)
        {
            List<Region> regions = new List<Region>();
            //Создание объекта Workbook 
            Workbook wb = new Workbook();
            // Загрузка данных из пути
            wb.LoadFromFile(path);
            //Получение первой рабочей страницы
            Worksheet ws = wb.Worksheets[0];
            bool isFlag = true; 
            foreach (var i in ws.Rows)
            {
                // Делаем из строки таблицы массив
                var list = i.ToArray();
                // Что бы не считывать певую строку
                if (isFlag)
                {
                    isFlag = false;
                    continue;
                }
                // Если есть коды, записываем название региона и все его коды
                if (list[2].Value.Length > 0)
                {
                    HashSet<RegionNumber> regionNumbers = new HashSet<RegionNumber>();
                    var str = list[2].Value.ToString().Split(" ").ToArray();
                    foreach(var j in str)
                    {
                        regionNumbers.Add(new RegionNumber(j));
                    }
                    regions.Add(new Region(list[1].Value.ToString(), regionNumbers));
                }
                // Либо же просто записываем название
                else
                {
                    regions.Add(new Region(list[1].Value.ToString()));
                }  
            }
            return regions;
        }
    }
}
