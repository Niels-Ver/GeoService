using DomainLayer.DomainLayer;
using DomainLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class CityRepository : ICityRepository
    {
        GeoServiceContext context;

        public CityRepository(GeoServiceContext context)
        {
            this.context = context;
        }

        public City GetCity(int id)
        {
            City city = context.Cities.FirstOrDefault(c => c.Id == id);
            return city;
        }

        public void RemoveCity(City city)
        {
            context.Cities.Remove(city);
            context.SaveChanges();
        }

        public void UpdateCity(City city)
        {
            City teUpdatenCity = context.Cities.Single(c => c.Id == city.Id);
            teUpdatenCity.Name = city.Name;
            teUpdatenCity.Population = city.Population;

            context.SaveChanges();

        }
    }
}
