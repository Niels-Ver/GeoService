using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLayer.DomainLayer
{
    public class River
    {
        public River(string name, double length)
        {
            Name = name;
            Length = length;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
    }
}
