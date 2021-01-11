using DomainLayer.DomainLayer;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoServiceTest.Domain
{
    [TestClass]
    public class CountryTest
    {
        [TestMethod]
        public void Population_ShouldThrowDomainException_WhenLowerOrEqualZero()
        {
            try
            {
                Country country = new Country("testLand", 0, 10);
                Country country2 = new Country("testLand", -1, 10);
            }
            catch (DomainException ex)
            {
                StringAssert.Contains(ex.Message, "The population mustn't equal or be lower then 0!");
                return;
            }
            Assert.Fail("De verwachte exceptie werd niet opgeroepen.");
        }

        [TestMethod]
        public void Surface_ShouldThrowDomainException_WhenLowerOrEqualZero()
        {
            try
            {
                Country country = new Country("testLand", 10, 0);
            }
            catch (DomainException ex)
            {
                StringAssert.Contains(ex.Message, "The surface area mustn't equal or be lower then 0!");
                return;
            }
            Assert.Fail("De verwachte exceptie werd niet opgeroepen.");

        }

        [TestMethod]
        public void AddCity_ShouldThrowDomainException_WhenTotalCityPopulationHigherThenPopulation()
        {
            Country country = new Country("testLand", 50, 10);

            Action act1 = () => country.AddCity(new City("TestStad1", 20));
            act1.Should().NotThrow<DomainException>();

            Action act2 = () => country.AddCity(new City("TestStad2", 20));
            act2.Should().NotThrow<DomainException>();

            Action act3 = () => country.AddCity(new City("TestStad3", 20));
            act3.Should().Throw<DomainException>();

        }

        [TestMethod]
        public void AddCapital_ShouldThrowDomainException_WhenCapitalNotInCities()
        {
            try
            {
                Country country = new Country("testLand", 50, 10);
                City city =  new City("TestStad", 20);
                country.AddCapital(city);
            }
            catch(DomainException ex)
            {
                StringAssert.Contains(ex.Message, "Capital is not present in Cities");
                return;
            }
            Assert.Fail("De verwachte exceptie werd niet opgeroepen.");
        }
    }
}
