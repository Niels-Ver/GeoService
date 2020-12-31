using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.DomainLayer
{
    public class Country
    {
        public Country(string name, int population, double surface)
        {
            Name = name;
            Population = population;
            Surface = surface;
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
                if (_population <= 0)
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
                if (_surface <= 0)
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
            Cities.Add(city);
        }
        public void AddRiver(River river)
        {
            Rivers.Add(river);
        }
    }
}
