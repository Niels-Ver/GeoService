using DataLayer.Repositories;
using DomainLayer;
using DomainLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private GeoServiceContext context;

        public UnitOfWork(GeoServiceContext context)
        {
            this.context = context;

            Continents = new ContinentRepository(context);
            Countries = new CountryRepository(context);
            Cities = new CityRepository(context);
            Rivers = new RiverRepository(context);
        }

        public IContinentRepository Continents { get; private set; }

        public ICountryRepository Countries { get; private set; }

        public ICityRepository Cities { get; private set; }

        public IRiverRepository Rivers { get; private set; }

        public int Complete()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
