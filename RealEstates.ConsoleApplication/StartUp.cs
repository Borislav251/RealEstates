using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;
using System;
using System.Text;

namespace RealEstates.ConsoleApplication
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var db = new RealEstateDbContext();
            db.Database.Migrate();

            IPropertiesService propertiesService = new PropertiesService(db);

            //propertiesService.Create("Драгалевци", 100, 2019, 210000, "4-СТАЕН", "ЕПК", 20, 20);
            //propertiesService.Create("Севера", 70, 1986, 50000, "2-СТАЕН", "ЕПК", 1, 8);

            IDistrictsService districtService = new DistrictsService(db);
            var districts = districtService.GetTopDistrictsByAveragePrice();

            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} => Price: {district.AveragePrice} ({district.MinPrice} - {district.MaxPrice}) => {district.PropertiesCount} properties");
            }

        }
    }
}
