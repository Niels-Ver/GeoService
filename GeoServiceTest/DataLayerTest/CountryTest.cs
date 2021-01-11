using DataLayer;
using DataLayer.Repositories;
using DomainLayer.DomainLayer;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoServiceTest.DataLayerTest
{
    [TestClass]
    public class CountryTest
    {
        GeoServiceContext context = new GeoServiceContextTest();

        [TestMethod]
        public void TestUpdateCountry()
        {
            ContinentRepository cr = new ContinentRepository(context);
            CountryRepository countryr = new CountryRepository(context);
            Continent c1 = new Continent("Continent");
            Country country1 = new Country("Country1", 10, 10);
            Country country2 = new Country("Country2", 10, 10);
            country2.Id = 1;

            cr.AddContinent(c1);
            cr.AddCountryToContinent(1, country1);
            countryr.GetCountry(1).Should().NotBeEquivalentTo(country2);
            countryr.UpdateCountry(country2);
            countryr.GetCountry(1).Should().Equals(country2);
        }

        [TestMethod]
        public void TestRemoveCountry()
        {
            ContinentRepository cr = new ContinentRepository(context);
            CountryRepository countryr = new CountryRepository(context);
            Continent c1 = new Continent("Continent");
            Country country1 = new Country("Country1", 10, 10);
            cr.AddContinent(c1);
            cr.AddCountryToContinent(1, country1);

            countryr.GetCountry(1).Should().NotBeNull();

            countryr.RemoveCountry(countryr.GetCountry(1));
            countryr.GetCountry(1).Should().BeNull();
        }

        [TestMethod]
        public void TestAddCityToCountry()
        {
            ContinentRepository cr = new ContinentRepository(context);
            CountryRepository countryr = new CountryRepository(context);
            CityRepository cityr = new CityRepository(context);
            Continent c1 = new Continent("Continent");
            Country country1 = new Country("Country1", 10, 10);
            Country country2 = new Country("Country2", 10, 10);

            cr.AddContinent(c1);
            cr.AddCountryToContinent(1, country1);
            cr.AddCountryToContinent(1, country2);

            City city1 = new City("City1", 1);
            City city2 = new City("City2", 2);
            City city3 = new City("City2", 2);

            countryr.AddCityToCountry(1, city1);
            countryr.AddCityToCountry(1, city2);
            countryr.AddCityToCountry(2, city3);

            var var1 = cityr.GetCity(1);
            var var2 = cityr.GetCity(2);
            var var3 = cityr.GetCity(3);

            var1.Should().Be(city1);
            var2.Should().Be(city2);
            var3.Should().Be(city3);
        }

        [TestMethod]
        public void Remove_ShouldThrowDataException_WhenCountriesNotEmpty()
        {
            ContinentRepository cr = new ContinentRepository(context);
            CountryRepository countryr = new CountryRepository(context);
            CityRepository cityr = new CityRepository(context);
            Continent c1 = new Continent("Continent");
            Country country1 = new Country("Country1", 10, 10);
            City city1 = new City("City1", 1);

            cr.AddContinent(c1);
            cr.AddCountryToContinent(1, country1);            
            countryr.AddCityToCountry(1, city1);

            Action act1 = () => countryr.RemoveCountry(countryr.GetCountry(1));
            act1.Should().Throw<DataException>();


            cityr.RemoveCity(cityr.GetCity(1));

            Action act2 = () => countryr.RemoveCountry(countryr.GetCountry(1));
            act2.Should().NotThrow<DataException>();
        }
    }
}
