using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.ApiBaseClass
{ 
    public class ApiRiver
    {
        public ApiRiver()
        {

        }

        public ApiRiver(int riverId, string name, double length)
        {
            RiverId = riverId;
            Name = name;
            Length = length;
        }

        public int RiverId { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
    }
}
