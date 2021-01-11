using DomainLayer.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Repositories
{
    public interface ICountryRepository
    {
        Country GetCountry(int id);
        //void AddCountry(Country country);
        void UpdateCountry(Country country);
        void RemoveCountry(Country country);

        public void AddCityToCountry(int id, City city);
        public void AddCapitolToCountry(int id, City city);
        public void AddRiverToCountry(int id, River river);
    }
}
