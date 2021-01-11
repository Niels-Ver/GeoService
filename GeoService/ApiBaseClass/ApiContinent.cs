using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.ApiBaseClass
{
    public class ApiContinent
    {
        public ApiContinent()
        {

        }

        public ApiContinent(string id, string name, int population, List<string> countries)
        {
            ContinentId = id;
            Name = name;
            Population = population;
            Countries = countries;
        }

        public string ContinentId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public List<string> Countries { get; set; }
    }
}
