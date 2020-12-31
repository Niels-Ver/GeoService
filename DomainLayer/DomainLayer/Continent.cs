using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.DomainLayer
{
    public class Continent
    {
        public Continent(string name, int population)
        {
            Name = name;
            Population = population;
        }

        public Continent(string name, int population, List<Country> countries)
        {
            Name = name;
            Population = population;
            Countries = countries;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Population 
        {
            get
            {
                int totalPopulation = 0;
                foreach (Country country in Countries)
                {
                    totalPopulation += country.Population;
                }
                return totalPopulation;
            }
            private set
            {
                throw new DomainException("The population of a continent cant be hard Set");
            }
        }
        public List<Country> Countries { get; set; }

        public void AddCountry(Country country)
        {
            Countries.Add(country);
        }
    }
}
