// See https://aka.ms/new-console-template for more information
using CarNumberGuideApp.Entity;

Console.WriteLine("Hello, World!");
RegistrationNumber reg = new RegistrationNumber("f3d1AA");
Console.WriteLine(reg.GetRegNumber());
RegionNumber rg = new RegionNumber("12");
Console.WriteLine( rg.ToString());
