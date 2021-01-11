using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.DomainLayer
{
    public class Country
    {
        public Country()
        {

        }

        public Country(string name, int population, double surface)
        {
            Name = name;
            Population = population;
            Surface = surface;
            Capitals = new List<City>();
            Cities = new List<City>();
            Rivers = new List<River>();
        }

        public Country(string name, int population, double surface, List<City> capitals, List<City> cities, List<River> rivers)
        {
            Name = name;
            Population = population;
            Surface = surface;
            Capitals = capitals;
            Cities = cities;
            Rivers = rivers;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        private int _population;
        public int Population 
        {
            get { return _population; }
            set
            {
                if (value <= 0)
                    throw new DomainException("The population mustn't equal or be lower then 0!");
                else
                    _population = value;
            }
        }
        private double _surface;
        public double Surface {
            get { return _surface; }
            set
            {
                if (value <= 0)
                    throw new DomainException("The surface area mustn't equal or be lower then 0!");
                else
                    _surface = value;
            }
        }

        public List<City> Capitals { get; set; }
        public List<City> Cities { get; set; }
        public List<River> Rivers { get; set; }

        public void AddCity(City city)
        {
            double citiesPopulation = 0;
            foreach (City c in Cities)
            {
               citiesPopulation += c.Population;
            }
            citiesPopulation += city.Population;
            if (citiesPopulation > Population)
                throw new DomainException("De totale populatie van alle steden samen is groter dan de populatie van het land!");
            Cities.Add(city);
        }
        public void AddCapital(City city)
        {
            if (Cities.Contains(city))
                Capitals.Add(city);
            else
                throw new DomainException("Capital is not present in Cities");
        }
        public void AddRiver(River river)
        {
            Rivers.Add(river);
        }
    }
}
