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
            if (!ExistsContinent(continent))
            {
                context.Continents.Add(continent);
                context.SaveChanges();
            }
            else
                throw new DataException("Er bestaat al een continent met deze naam!");
            
        }

        public List<Continent> GetContinents()
        {
            List<Continent> continents = context.Continents.Include(c => c.Countries).ToList();
            return continents;
        }

        public Continent GetContinent(int id)
        {
            Continent continent = context.Continents.Include(c =>c.Countries).FirstOrDefault(x => x.Id == id);
            if (continent != null)
                return continent;
            else
                throw new DataException("No Continent for that id");
        }

        public void RemoveContinent(Continent continent)
        {
            if (continent.Countries.Count == 0)
            {
                context.Continents.Remove(continent);
                context.SaveChanges();
            }
            else
                throw new DataException("Alle landen moeten verwijderd zijn voordat continent verwijderd kan worden");
            
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

        public bool ExistsContinent(Continent continent)
        {
            bool continentFound = false;
            foreach (Continent c in context.Continents)
            {
                if (c.Name.Equals(continent.Name))
                    continentFound = true;
            }
            return continentFound;
        }

    }
}
