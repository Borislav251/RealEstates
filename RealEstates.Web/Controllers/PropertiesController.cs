using Microsoft.AspNetCore.Mvc;
using RealEstates.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstates.Web.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertiesService propertiesService;

        public PropertiesController(IPropertiesService propertiesService)
        {
            this.propertiesService = propertiesService;
        }

        public IActionResult SearchByPrice()
        {
            return this.View();
        }

        public IActionResult DoSearchByPrice(int minPrice, int maxPrice)
        {
            var properties = this.propertiesService.SearchByPrice(minPrice, maxPrice);
            return this.View(properties);
        }

        public IActionResult SearchByYearAndSize()
        {
            return this.View();
        }

        public IActionResult DoSearchByYearAndSize(int minYear, int maxYear, int minSize, int maxSize)
        {
            var properties = this.propertiesService.SearchByYearAndSize(minYear, maxYear, minSize, maxSize);
            return this.View(properties);
        }
    }
}
