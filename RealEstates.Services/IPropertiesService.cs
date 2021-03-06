using System.Collections.Generic;

using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public interface IPropertiesService
    {
        void Create(string district, int size, int? year, int price, string propertyType, string buildingType, int? floor, int? maxFloors);

        void UpdateTags(int propertyId);

        IEnumerable<PropertyViewModel> SearchByYearAndSize(int minYear, int maxYear, int minSize, int maxSize);

        IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice);
    }
}
