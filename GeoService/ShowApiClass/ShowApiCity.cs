using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.ShowApiClass
{
    public class ShowApiCity
    {
        public ShowApiCity()
        {

        }

        public ShowApiCity(string continentID, string countryId, int cityId, string name, int population)
        {
            ContinentId = continentID;
            CountryId = countryId;
            CityId = cityId;
            Name = name;
            Population = population;
        }

        public string ContinentId { get; set; }
        public string CountryId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
    }
}
