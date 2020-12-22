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
    public class ManufacturersController : ControllerBase
    {
        private readonly RentCarContext _context;

        public ManufacturersController(RentCarContext context)
        {
            _context = context;
        }

        // GET: api/Manufacturers/GetManufacturers
        [HttpGet("[action]")]
        public async Task<IEnumerable<Manufacturer>> GetManufacturers()
        {
            var manufacturer = await _context.Manufacturers.ToListAsync();
            return manufacturer.Select(c => new Manufacturer{
                ManufacturerId = c.ManufacturerId,
                ManufacturerName = c.ManufacturerName
            });
        }

        // GET: api/Manufacturers/GetManufacturer/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Manufacturer>> GetManufacturer([FromRoute]int id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new Manufacturer
                {
                    ManufacturerId = manufacturer.ManufacturerId,
                    ManufacturerName = manufacturer.ManufacturerName
                });
            }

           
        }

       
    }
}
