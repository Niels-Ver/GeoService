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
            return country;
        }

        public void RemoveCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public void UpdateCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public void AddCityToCountry(int id, City city)
        {
            throw new NotImplementedException();
        }

        public void AddRiverToCountry(int id, River river)
        {
            throw new NotImplementedException();
        }
    }
}
