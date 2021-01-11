using DataLayer;
using DomainLayer.DomainLayer;
using DomainLayer.Repositories;
using GeoService.ApiBaseClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace GeoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentController : ControllerBase
    {
        private IContinentRepository continentRepo;
        private ILogger logger;

        public ContinentController(IContinentRepository continentRepo, ILoggerFactory loggerFactory)
        {
            this.continentRepo = continentRepo;
            this.logger = loggerFactory.AddFile("ContinentLogs.txt").CreateLogger("Continent");
        }

        [HttpPost]
        public ActionResult<Continent> Post([FromBody] Continent continent)
        {
            logger.LogInformation("Post continent called");
            try
            {
                continentRepo.AddContinent(continent);
                return CreatedAtAction(nameof(Get), new { id = continent.Id }, Mapper.ApiContinentMapper(continent));
            }
            catch (ApiException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ApiContinent> Get(int id)
        {
            logger.LogInformation(id,"Get continent (" + id + ") called");
            try
            {
                return Ok(Mapper.ApiContinentMapper(continentRepo.GetContinent(id)));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            logger.LogInformation(id, "Remove continent (" + id + ") called");
            try
            {
                continentRepo.RemoveContinent(continentRepo.GetContinent(id));
                return NoContent();
            }
            catch (ApiException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DataException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Continent> Put(int id, [FromBody] Continent continent)
        {
            logger.LogInformation(id, "Update continent (" + id + ") called");
            try
            {
                if (continent.Id != id)
                    return BadRequest();
                continentRepo.UpdateContinent(continent);
                return CreatedAtAction(nameof(Get), new { id = continent.Id }, Mapper.ApiContinentMapper(continent));
            }
            catch (ApiException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("{id}/country")]
        public ActionResult<Continent> Post(int id, [FromBody] ApiCountry apiCountry)
        {
            logger.LogInformation(id, "Post country called for continent (" + id + ") called");
            try
            {
                if (apiCountry.ContinentId != id)
                    return BadRequest();

                
                continentRepo.AddCountryToContinent(id, Mapper.CountryMapper(apiCountry));
                return CreatedAtAction(nameof(Post), new { id = apiCountry.CountryId }, apiCountry);
            }
            catch(ApiException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
