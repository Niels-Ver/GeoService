using DomainLayer.DomainLayer;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoServiceTest.Domain
{
    [TestClass]
    public class ContinentTest
    {
        [TestMethod()]
        public void AddCountryTest()
        {
            Continent continent = new Continent("Continent");
            Country country1 = new Country("Land1", 10, 10);
            Country country2 = new Country("Land2", 10, 10);

            continent.AddCountry(country1);
            continent.Countries.Count.Should().Be(1);
            continent.AddCountry(country2);
            continent.Countries.Count.Should().Be(2);
        }

        [TestMethod()]
        public void ShouldThrowDomainException_WhenCountryNameDuplicate()
        {
            try
            {
                Continent continent = new Continent("Alaska");
                continent.AddCountry(new Country("AlaskaLand", 2, 20));
                continent.AddCountry(new Country("AlaskaLand", 2, 20));
            }
            catch (DomainException ex)
            {
                StringAssert.Contains(ex.Message, "Er bevind zich al een land met deze naam in dit continent!");
                return;
            }
            Assert.Fail("De verwachte exceptie werd niet opgeroepen");
        }

        [TestMethod]
        public void ContinentPopulation_ShouldEqualTotalCityPopulation()
        {
            Continent continent = new Continent("Continent");
            Country country1 = new Country("Land1", 10, 10);
            Country country2 = new Country("Land2", 15, 10);
            Country country3 = new Country("Land3", 18, 10);

            continent.Population.Should().Be(0);
            continent.AddCountry(country1);
            continent.Population.Should().Be(10);
            continent.AddCountry(country2);
            continent.Population.Should().Be(25);
            continent.AddCountry(country3);
            continent.Population.Should().Be(43);
        }

    }
}
