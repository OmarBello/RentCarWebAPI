using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarWebAPI.Models;

namespace RentCarWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly RentCarContext _context;

        public CitiesController(RentCarContext context)
        {
            _context = context;
        }

        // GET: api/Cities/GetCities
        [HttpGet("[action]")]
        public async Task<IEnumerable<City>> GetCities()
        {
            var city = await _context.Cities.ToListAsync();
            return city.Select(c => new City
            {
                CityId = c.CityId,
                CityName = c.CityName
            });
        }

        // GET: api/Cities/GetCity/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<City>> GetCity([FromRoute] int id)
        {
            var city = await _context.Cities.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new City
                {
                    CityId = city.CityId,
                    CityName = city.CityName
                });
            }


        }


    }
}
