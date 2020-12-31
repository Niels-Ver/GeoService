using DomainLayer.DomainLayer;
using DomainLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class ContinentRepository : IContinentRepository
    {

        GeoServiceContext context;

        public ContinentRepository(GeoServiceContext context)
        {
            this.context = context;
        }

        public void AddContinent(Continent continent)
        {
            context.Continents.Add(continent);
        }

        public Continent GetContinent(int id)
        {
            Continent continent = context.Continents.Include(c =>c.Countries).FirstOrDefault(x => x.Id == id);
            return continent;
        }

        public void RemoveContinent(Continent continent)
        {
            context.Continents.Remove(continent);
        }

        public void UpdateContinent(Continent continent)
        {
            Continent teUpdatenContinent = context.Continents.Single(c => c.Id == continent.Id);
            teUpdatenContinent.Name = continent.Name;
            teUpdatenContinent.Countries = continent.Countries;
            context.SaveChanges();
        }

        public void AddCountryToContinent(int id, Country country)
        {
            Continent teUpdatenContinent = GetContinent(id);
            teUpdatenContinent.AddCountry(country);
            context.SaveChanges();
        }
    }
}
