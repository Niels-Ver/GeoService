using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.ApiBaseClass
{
    public class ApiCity
    {
        public ApiCity()
        {

        }

        public ApiCity(int continentID, int countryId, int cityId, string name, int population)
        {
            ContinentId = continentID;
            CountryId = countryId;
            CityId = cityId;
            Name = name;
            Population = population;
        }

        public int ContinentId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
    }
}
