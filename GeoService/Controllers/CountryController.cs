using DataLayer;
using DomainLayer.DomainLayer;
using DomainLayer.Repositories;
using GeoService.ApiBaseClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.Controllers
{
    [Route("api/continent/{continentId}/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryRepository countryRepo;
        private readonly ILogger logger;

        public CountryController(ICountryRepository countryRepo, ILoggerFactory loggerFactory)
        {
            this.countryRepo = countryRepo;
            this.logger = loggerFactory.AddFile("CountryLogs.txt").CreateLogger("Country");
        }

        [HttpGet("{id}")]
        public ActionResult<ApiCountry> Get(int continentId, int id)
        {
            logger.LogInformation("Get continent called");

            try
            {
                //return Ok(Mapper.ApiCountryMapper(continentId, countryRepo.GetCountry(id)));

                return Ok(Mapper.ShowApiCountryMapper(continentId, countryRepo.GetCountry(id)));
            }
            catch (ApiException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ApiCountry> Put(int continentId, int id, [FromBody] Country country)
        {
            try
            {
                if (country.Id != id)
                    return BadRequest();
                countryRepo.UpdateCountry(country);
                return CreatedAtAction(nameof(Get), new { id = country.Id }, Mapper.ApiCountryMapper(continentId, country));
            }
            catch (ApiException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                countryRepo.RemoveCountry(countryRepo.GetCountry(id));
                return NoContent();
            }
            catch (ApiException ex){return NotFound(ex.Message);}
            catch (DataException ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("{id}/city")]
        public ActionResult<Country> Post(int continentId, int id, [FromBody] ApiCity apiCity )
        {
            try
            {
                if (apiCity.CountryId != id)
                    return BadRequest();
                countryRepo.AddCityToCountry(id, Mapper.CityMapper(apiCity));
                return CreatedAtAction(nameof(Post), new { id = apiCity.CityId }, Mapper.CityMapper(apiCity));
            }
            catch(ApiException ex){return NotFound(ex.Message);}
            catch(DataException ex) { return BadRequest(ex.Message); }
        }

    }
}
