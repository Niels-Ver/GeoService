using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLayer.DomainLayer
{
    public class City
    {
        public City(string name, int population)
        {
            Name = name;
            Population = population;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
    }
}
