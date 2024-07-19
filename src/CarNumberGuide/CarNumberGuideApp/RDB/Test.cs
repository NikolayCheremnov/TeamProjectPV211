using CarNumberGuideApp.Entity;
using CarNumberGuideApp.RDB.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNumberGuideApp.RDB
{
    internal class Test
    {
        public static void Repositories()
        {
            using (var context = new AppDbContext(new DbContextOptions<AppDbContext>()))
            {
                // Создание репозиториев
                var regionRepository = new RegionRepository(context);
                var regionNumberRepository = new RegionNumberRepository(context);
                var registrationNumberRepository = new RegistrationNumberRepository(context);

                // Создание нового региона
                var newRegion = regionRepository.CreateRegion("New Region", new HashSet<RegionNumber>());
                Console.WriteLine($"Создан регион с именем: {newRegion.Name}");

                // Создание нового номера региона
                var newRegionNumber = regionNumberRepository.CreateRegionNumber("22RUS", newRegion);
                Console.WriteLine($"Создан номер региона с ID: {newRegionNumber.Id} и кодом: {newRegionNumber.Code}");

                // Создание нового регистрационного номера
                var newRegistrationNumber = registrationNumberRepository.CreateRegistrationNumber("A001BC", newRegionNumber);
                Console.WriteLine($"Создан регистрационный номер с ID: {newRegistrationNumber.Id} и символическим кодом: {newRegistrationNumber.SymbolicCode}");

                // Чтение данных из базы
                var regionFromDb = regionRepository.GetById(newRegion.Id);
                Console.WriteLine($"Извлечен регион с ID: {regionFromDb.Id} и именем: {regionFromDb.Name}");

                var regionNumberFromDb = regionNumberRepository.GetById(newRegionNumber.Id);
                Console.WriteLine($"Извлечен номер региона с ID: {regionNumberFromDb.Id} и кодом: {regionNumberFromDb.Code}");

                var registrationNumberFromDb = registrationNumberRepository.GetById(newRegistrationNumber.Id);
                Console.WriteLine($"Извлечен регистрационный номер с ID: {registrationNumberFromDb.Id} и символическим кодом: {registrationNumberFromDb.SymbolicCode}");

                // Обновление данных в базе
                regionFromDb.Name = "Updated Region";
                regionRepository.UpdateRegion(regionFromDb);
                Console.WriteLine($"Обновлен регион с ID: {regionFromDb.Id} и новым именем: {regionFromDb.Name}");

                regionNumberFromDb.Code = "777RUS";
                regionNumberRepository.UpdateRegionNumber(regionNumberFromDb);
                Console.WriteLine($"Обновлен номер региона с ID: {regionNumberFromDb.Id} и новым кодом: {regionNumberFromDb.Code}");

                registrationNumberFromDb.SymbolicCode = "B002CD";
                registrationNumberRepository.UpdateRegistrationNumber(registrationNumberFromDb);
                Console.WriteLine($"Обновлен регистрационный номер с ID: {registrationNumberFromDb.Id} и новым символическим кодом: {registrationNumberFromDb.SymbolicCode}");

                Console.WriteLine("\n\nПродолжить выполнение?\n\n");
                Console.ReadLine();

                // Удаление данных из базы
                registrationNumberRepository.DeleteRegistrationNumber(registrationNumberFromDb);
                Console.WriteLine($"Удален регистрационный номер с ID: {registrationNumberFromDb.Id}");

                regionNumberRepository.DeleteRegionNumber(regionNumberFromDb);
                Console.WriteLine($"Удален номер региона с ID: {regionNumberFromDb.Id}");

                regionRepository.DeleteRegion(regionFromDb);
                Console.WriteLine($"Удален регион с ID: {regionFromDb.Id}");

                // Проверка удаления
                if (regionRepository.GetById(regionFromDb.Id) == null)
                {
                    Console.WriteLine("Регион успешно удален.");
                }

                if (regionNumberRepository.GetById(regionNumberFromDb.Id) == null)
                {
                    Console.WriteLine("Номер региона успешно удален.");
                }

                if (registrationNumberRepository.GetById(registrationNumberFromDb.Id) == null)
                {
                    Console.WriteLine("Регистрационный номер успешно удален.");
                }
            }
        }
    }
}
