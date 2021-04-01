using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

using RealEstates.Data;
using RealEstates.Services;

namespace RealEstates.Importer
{
    partial class StartUp
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText("imot.bg-raw-data-2020-07-23.json");
            var properties = JsonSerializer.Deserialize<IEnumerable<JsonProperty>>(json);
            var db = new RealEstateDbContext();
            IPropertiesService propertiesService = new PropertiesService(db);
            foreach (var property in properties.Where(p => p.Price > 1000))
            {
                try
                {
                    propertiesService.Create(
                        property.District,
                        property.Size,
                        property.Year,
                        property.Price,
                        property.Type,
                        property.BuildingType,
                        property.Floor,
                        property.TotalFloors);
                }
                catch
                {
                }
            }
        }
    }
}
