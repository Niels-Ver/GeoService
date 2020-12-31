using ConsoleAppLayer.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLayer.Repositories
{
    public interface ICountryRepository
    {
        Country getCountry(int id);
        void AddCountry(Country country);
        void UpdateCountry(Country country);
        void RemoveCountry(Country country);
    }
}
