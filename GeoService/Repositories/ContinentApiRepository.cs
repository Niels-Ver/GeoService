using DataLayer;
using DomainLayer.DomainLayer;
using DomainLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.Repositories
{
    public class ContinentApiRepository : IContinentRepository
    {
        private GeoServiceManager manager;

        public ContinentApiRepository()
        {
            manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContext()));
        }

        public void AddContinent(Continent continent)
        {
            manager.AddContinent(continent);
        }

        public void AddCountryToContinent(int id, Country country)
        {
            manager.AddCountryToContinent(id, country);
        }

        public bool ExistsContinent(Continent continent)
        {
            return manager.ExistsContinent(continent);
        }

        public Continent GetContinent(int id)
        {
            return manager.GetContinent(id);
        }

        public void RemoveContinent(Continent continent)
        {
            manager.RemoveContinent(continent);
        }

        public void UpdateContinent(Continent continent)
        {
            manager.UpdateContinent(continent);
        }
    }
}
