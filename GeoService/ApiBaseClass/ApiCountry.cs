using DomainLayer.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.ApiBaseClass
{
    public class ApiCountry
    {
        public ApiCountry()
        {

        }

        public ApiCountry(int continentID, int countryId, string name, int population, double surface)
        {
            ContinentId = continentID;
            CountryId = countryId;
            Name = name;
            Population = population;
            Surface = surface;
            Capitals = new List<string>();
            Cities = new List<string>();
            Rivers = new List<string>();

        }

        public ApiCountry(int continentID, string name, int population, double surface, List<string> capitals, List<string> cities, List<string> rivers)
        {
            ContinentId = continentID;
            Name = name;
            Population = population;
            Surface = surface;
            Capitals = capitals;
            Cities = cities;
            Rivers = rivers;
        }

        public int ContinentId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public double Surface { get; set; }
        public List<string> Capitals { get; set; }
        public List<string> Cities { get; set; }
        public List<string> Rivers { get; set; }
    }
}
