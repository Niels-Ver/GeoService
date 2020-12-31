using ConsoleAppLayer.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;


namespace ConsoleAppLayer.Repositories
{
    public interface IContinentRepository
    {
        Continent getContinent(int id);
        void AddContinent(Continent continent);
        void UpdateContinent(Continent continent);
        void RemoveContinent(Continent continent);
    }
}
