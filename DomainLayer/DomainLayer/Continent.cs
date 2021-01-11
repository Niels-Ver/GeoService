using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.DomainLayer
{
    public class Continent
    {

        public Continent()
        {

        }

        public Continent(string name)
        {
            Name = name;
            //Population = population;
            Countries = new List<Country>();
        }

        public Continent(string name, int population, List<Country> countries)
        {
            Name = name;
            Population = population;
            Countries = countries;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Country> Countries { get; set; }
        public int Population 
        {
            get
            {
                if (Countries != null)
                {
                    int totalPopulation = 0;
                    foreach (Country country in Countries)
                    {
                        totalPopulation += country.Population;
                    }
                    return totalPopulation;
                }
                return 0;
            }
            set
            {
                //throw new DomainException("The population of a continent cant be hard Set");
            }
        }
        

        public void AddCountry(Country country)
        {
            if (!ContinentHasCountryWithName(country))
                Countries.Add(country);
            else
                throw new DomainException("Er bevind zich al een land met deze naam in dit continent!");
        }

        private bool ContinentHasCountryWithName(Country country)
        {
            bool hasCountry = false;
            if(Countries != null)
            {
                foreach (Country c in Countries)
                {
                    if (c.Name == country.Name)
                        hasCountry = true;
                }
            }
            
            return hasCountry;
        }
    }
}
