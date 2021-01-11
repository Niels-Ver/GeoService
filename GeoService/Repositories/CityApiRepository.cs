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
    public class CityApiRepository : ICityRepository
    {
        private GeoServiceManager manager;

        public CityApiRepository()
        {
            this.manager = new GeoServiceManager(new UnitOfWork(new GeoServiceContext()));
        }

        public City GetCity(int id)
        {
            return manager.GetCity(id);
        }

        public void RemoveCity(City city)
        {
            manager.RemoveCity(city);
        }

        public void UpdateCity(City city)
        {
            manager.UpdateCity(city);
        }
    }
}
