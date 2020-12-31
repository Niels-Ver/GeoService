using ConsoleAppLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLayer
{
    public interface IUnitOfWork
    {
        public IContinentRepository Continents { get; }
        public ICountryRepository Countries { get; }
        public ICityRepository Cities { get; }
        public IRiverRepository Rivers { get;  }

        int Complete();
    }
}
