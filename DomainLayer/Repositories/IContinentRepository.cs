using DomainLayer.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;


namespace DomainLayer.Repositories
{
    public interface IContinentRepository
    {
        Continent GetContinent(int id);
        void AddContinent(Continent continent);
        void UpdateContinent(Continent continent);
        void RemoveContinent(Continent continent);

        void AddCountryToContinent(int id, Country country);
    }
}
