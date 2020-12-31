using DomainLayer.DomainLayer;
using DomainLayer.Repositories;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void RemoveCity(City city)
        {
            throw new NotImplementedException();
        }

        public void UpdateCity(City city)
        {
            throw new NotImplementedException();
        }
    }
}
