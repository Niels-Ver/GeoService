using DomainLayer.DomainLayer;
using DomainLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private GeoServiceContext context;

        public CountryRepository(GeoServiceContext context)
        {
            this.context = context;
        }

        public Country GetCountry(int id)
        {
            Country country = context.Countries.Include(c => c.Capitals).Include(c => c.Cities).Include(r => r.Rivers).FirstOrDefault(c => c.Id == id);
            if (country != null)
                return country;
            else
                throw new DataException("Geen land voor deze id gevonden");
        }

        public void RemoveCountry(Country country)
        {
            if (country.Cities.Count == 0)
            {
                context.Countries.Remove(country);
                context.SaveChanges();
            }
            else
                throw new DataException("Alle steden moeten verwijderd zijn voordat continent verwijderd kan worden");
        }

        public void UpdateCountry(Country country)
        {
            Country teUpdatenCountry = context.Countries.Single(c => c.Id == country.Id);
            teUpdatenCountry.Name = country.Name;
            teUpdatenCountry.Population = country.Population;
            teUpdatenCountry.Surface = country.Surface;

            if(country.Cities != null)
            {
                teUpdatenCountry.Cities = country.Cities;
            }
            if (country.Capitals != null)
            {
                teUpdatenCountry.Capitals = country.Capitals;
            }
            if (country.Rivers != null)
            {
                teUpdatenCountry.Rivers = country.Rivers;
            }

            context.SaveChanges();
        }

        public void AddCityToCountry(int id, City city)
        {
            Country teUpdateCountry = GetCountry(id);
            teUpdateCountry.AddCity(city);
            context.SaveChanges();
        }

        public void AddRiverToCountry(int id, River river)
        {
            Country teUpdateCountry = GetCountry(id);
            teUpdateCountry.AddRiver(river);
            context.SaveChanges();
        }

        public void AddCapitolToCountry(int id, City city)
        {
            Country teUpdateCountry = GetCountry(id);
            teUpdateCountry.AddCapital(city);
            context.SaveChanges();
        }
    }
}
