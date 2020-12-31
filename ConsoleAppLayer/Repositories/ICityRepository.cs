using ConsoleAppLayer.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLayer.Repositories
{
    public interface ICityRepository
    {
        City getCity(int id);
        void AddCity(City city);
        void UpdateCity(City city);
        void RemoveCity(City city);
    }
}
