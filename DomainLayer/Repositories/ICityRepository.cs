using DomainLayer.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Repositories
{
    public interface ICityRepository
    {
        City GetCity(int id);
        //void AddCity(City city);
        void UpdateCity(City city);
        void RemoveCity(City city);
    }
}
