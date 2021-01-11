using DomainLayer.DomainLayer;
using DomainLayer.Repositories;
using GeoService.ApiBaseClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.Controllers
{
    [Route("api/continent/{continentId}/country/{countryId}/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private ICityRepository cityRepo;
        private ILogger logger;

        public CityController(ICityRepository cityRepo, ILoggerFactory loggerFactory)
        {
            this.cityRepo = cityRepo;
            this.logger = loggerFactory.AddFile("CityLogs.txt").CreateLogger("City");
        }

        [HttpGet("{id}")]
        public ActionResult<ApiCity> Get(int continentId, int countryId, int id)
        {
            try
            {
                return Ok(Mapper.ApiCityMapper(continentId, countryId, cityRepo.GetCity(id)));
            }
            catch(ApiException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<City> Put(int continentId, int countryId, int id, [FromBody] City city)
        {
            if (city.Id != id)
                return BadRequest();
            cityRepo.UpdateCity(city);
            return CreatedAtAction(nameof(Get), new { id = city.Id }, Mapper.ApiCityMapper(continentId, countryId, city));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                cityRepo.RemoveCity(cityRepo.GetCity(id));
                return NoContent();
            }
            catch (ApiException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
