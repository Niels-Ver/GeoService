using DataLayer;
using DomainLayer.DomainLayer;
using DomainLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.Repositories
{
    public class CountryApiRepository : ICountryRepository
    {
        private GeoServiceManager manager;

        public CountryApiRepository()
        {
            this.manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContext()));
        }

        public void AddCapitolToCountry(int id, City city)
        {
            manager.AddCapitolToCountry(id, city);
        }

        public void AddCityToCountry(int id, City city)
        {
            manager.AddCityToCountry(id, city);
        }

        public void AddRiverToCountry(int id, River river)
        {
            throw new NotImplementedException();
        }

        public Country GetCountry(int id)
        {
            return manager.GetCountry(id);
        }

        public void RemoveCountry(Country country)
        {
            manager.RemoveCountry(country);
        }

        public void UpdateCountry(Country country)
        {
            manager.UpdateCountry(country);
        }
    }
}
