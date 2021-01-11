using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.DomainLayer
{
    public class GeoServiceManager
    {
        private IUnitOfWork uow;

        public GeoServiceManager(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        #region Continent

        public void AddContinent(Continent continent)
        {
            uow.Continents.AddContinent(continent);
            uow.Complete();
        }

        public void RemoveContinent(Continent continent)
        {
            uow.Continents.RemoveContinent(continent);
            uow.Complete();
        }

        public void UpdateContinent(Continent continent)
        {
            uow.Continents.UpdateContinent(continent);
            uow.Complete();
        }

        public Continent GetContinent(int id)
        {
            return uow.Continents.GetContinent(id);
        }

        public bool ExistsContinent(Continent continent)
        {
            return uow.Continents.ExistsContinent(continent);
        }

        public void AddCountryToContinent(int id, Country country)
        {
            uow.Continents.AddCountryToContinent(id, country);
            uow.Complete();
        }

        #endregion

        #region Country
        public Country GetCountry(int id)
        {
            return uow.Countries.GetCountry(id);
        }

        public void AddCityToCountry(int id, City city)
        {
            uow.Countries.AddCityToCountry(id, city);
            uow.Complete();
        }

        public void AddRiverToCountry(int id, River river)
        {
            uow.Countries.AddRiverToCountry(id, river);
            uow.Complete();
        }

        public void AddCapitolToCountry(int id, City city)
        {
            uow.Countries.AddCapitolToCountry(id, city);
            uow.Complete();
        }

        public void UpdateCountry(Country country)
        {
            uow.Countries.UpdateCountry(country);
            uow.Complete();
        }

        public void RemoveCountry(Country country)
        {
            uow.Countries.RemoveCountry(country);
            uow.Complete();
        }
        #endregion

        #region City

        public City GetCity(int id)
        {
            return uow.Cities.GetCity(id);
        }

        public void RemoveCity(City city)
        {
            uow.Cities.RemoveCity(city);
            uow.Complete();
        }

        public void UpdateCity(City city)
        {
            uow.Cities.UpdateCity(city);
            uow.Complete();
        }


        #endregion



    }
}
