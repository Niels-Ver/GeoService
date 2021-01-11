using DomainLayer.DomainLayer;
using GeoService.ApiBaseClass;
using GeoService.ShowApiClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService
{
    public class Mapper
    {
        public static ApiContinent ApiContinentMapper(Continent continent)
        {
            try
            {
                List<string> countries = new List<string>();

                if(continent.Countries != null)
                {
                    foreach (Country country in continent.Countries)
                    {
                        countries.Add("http://localhost:50051/api/continent/" + continent.Id + "/country/" + country.Id);
                    }
                }                

                return new ApiContinent("http://localhost:50051/api/continent/" + continent.Id, continent.Name, continent.Population, countries);
            }
            catch
            {

                throw new ApiException("Er is geen continent gevonden voor die Id");
            }

        }          



        public static ApiCountry ApiCountryMapper(int continentId, Country country)
        {
            try
            {
                ApiCountry apiCountry = new ApiCountry(continentId, country.Id, country.Name, country.Population, country.Surface);

                if (country.Cities != null)
                {
                    apiCountry.Cities = Mapper.CountryCityMapper(continentId, country.Id, country.Cities);
                }

                if (country.Rivers != null)
                {
                    apiCountry.Rivers = Mapper.CountryRiverMapper(continentId, country.Id, country.Rivers);
                }
                return apiCountry;
            }
            catch
            {
                throw new ApiException("Er is geen land voor de meegegeven Id");
            }           
        }

        public static ShowApiCountry ShowApiCountryMapper(int continentId, Country country)
        {
            try
            {
                ShowApiCountry showApiCountry = new ShowApiCountry("http://localhost:50051/api/continent/" + continentId, "http://localhost:50051/api/continent/" + continentId + "/country/" + country.Id, country.Name, country.Population, country.Surface);
                if(country.Cities != null)
                {
                    showApiCountry.Cities = Mapper.CountryCityMapper(continentId, country.Id, country.Cities);
                }
                if (country.Rivers != null)
                {
                    showApiCountry.Rivers = Mapper.CountryRiverMapper(continentId, country.Id, country.Rivers);
                }
                return showApiCountry;

            }
            catch
            {
                throw new ApiException("Er is geen land voor de meegegeven Id");
            }
        }

        

        private static List<string> CountryRiverMapper(int continentId, int countryId, List<River> rivers)
        {
            List<string> apiRivers = new List<string>();

            foreach (River river in rivers)
            {
                apiRivers.Add("http://localhost:50051/api/continent/" + continentId + "/country/" + countryId + "/river/" + river.Id);
            }

            return apiRivers;
        }

        private static List<string> CountryCityMapper(int continentId, int countryId, List<City> cities)
        {
            List<string> apiCities = new List<string>();

            foreach (City city in cities)
            {
                apiCities.Add("http://localhost:50051/api/continent/" + continentId + "/country/" + countryId + "/city/" + city.Id);
            }

            return apiCities;
        }


        public static ApiCity ApiCityMapper(int continentId, int countryId, City city)
        {
            return new ApiCity(continentId, countryId, city.Id, city.Name, city.Population); 
        }

        public static Country CountryMapper(ApiCountry apiCountry)
        {
            return new Country(apiCountry.Name, apiCountry.Population, apiCountry.Surface);
        }

        public static City CityMapper(ApiCity apiCity)
        {
            return new City(apiCity.Name, apiCity.Population);
        }
    }
}
