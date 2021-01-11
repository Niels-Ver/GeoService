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
    public class ContinentTest
    {
        GeoServiceContext context = new GeoServiceContextTest();

        [TestMethod]
        public void TestAddContinent()
        {
            ContinentRepository cr = new ContinentRepository(context);
            Continent c1 = new Continent("Continent1");
            Continent c2 = new Continent("Continent2");


            cr.AddContinent(c1);
            var result = cr.GetContinents();
            result.Count.Should().Be(1);

            cr.AddContinent(c2);
            result = cr.GetContinents();
            result.Count.Should().Be(2);
        }

        [TestMethod]
        public void DoubleContinentShouldThrowDataException()
        {
            ContinentRepository cr = new ContinentRepository(context);
            Continent c1 = new Continent("Continent1");
            Continent c2 = new Continent("Continent1");


            Action act1 = () => cr.AddContinent(c1);
            act1.Should().NotThrow<DataException>();

            Action act2 = () => cr.AddContinent(c2);
            act1.Should().Throw<DataException>();
        }

        [TestMethod]
        public void Remove_ShouldThrowDataException_WhenCountriesNotEmpty()
        {
            ContinentRepository cr = new ContinentRepository(context);
            CountryRepository countryr = new CountryRepository(context);

            Continent c1 = new Continent("Continent1");
            Country country = new Country("Country", 10, 10);

            cr.AddContinent(c1);
            cr.AddCountryToContinent(1, country);

            Action act1 = () => cr.RemoveContinent(c1);
            act1.Should().Throw<DataException>();
            Country removecountry = countryr.GetCountry(1);
            countryr.RemoveCountry(removecountry);

            Action act2 = () => cr.RemoveContinent(c1);
            act2.Should().NotThrow<DataException>();
        }

        [TestMethod]
        public void TestUpdateContinent()
        {
            ContinentRepository cr = new ContinentRepository(context);
            Continent c1 = new Continent("Continent");
            Continent continentToUpdate = new Continent("ContinentUpdate");
            cr.AddContinent(c1);
            cr.GetContinent(1).Should().NotBeEquivalentTo(continentToUpdate);
            continentToUpdate.Id = 1;
            cr.UpdateContinent(continentToUpdate);
            cr.GetContinent(1).Should().Equals(continentToUpdate);

            context.Dispose();
        }

        [TestMethod]
        public void TestRemoveContinent()
        {
            ContinentRepository cr = new ContinentRepository(context);
            Continent c1 = new Continent("Continent");
            cr.AddContinent(c1);
            cr.GetContinent(1).Should().NotBeNull();

            cr.RemoveContinent(c1);
            cr.GetContinent(1).Should().BeNull();

            context.Dispose();
        }        

        [TestMethod]
        public void TestAddCountryToContinent()
        {
            ContinentRepository cr = new ContinentRepository(context);
            CountryRepository countryr = new CountryRepository(context);
            Continent c1 = new Continent("Continent");
            cr.AddContinent(c1);
            Country country1 = new Country("Country1", 10, 10);
            Country country2 = new Country("Country2", 10, 10);

            cr.AddCountryToContinent(1, country1);
            cr.AddCountryToContinent(1, country2);

            var var1 = countryr.GetCountry(1);
            var var2 = countryr.GetCountry(2);

            var1.Should().Be(country1);
            var1.Should().NotBeEquivalentTo(country2);
            var2.Should().Be(country2);
            var2.Should().NotBeEquivalentTo(country1);
        }
    }
}
