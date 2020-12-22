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
    public class FuelTypesController : ControllerBase
    {
        private readonly RentCarContext _context;

        public FuelTypesController(RentCarContext context)
        {
            _context = context;
        }

        // GET: api/FuelTypes/GetFuelTypes
        [HttpGet("[action]")]
        public async Task<IEnumerable<FuelType>> GetFuelTypes()
        {
            var fuelTypes =  await _context.FuelTypes.ToListAsync();

            return fuelTypes.Select(c => new FuelType
            {
                FuelTypeId = c.FuelTypeId,
                FuelName = c.FuelName
            });
        }

        // GET: api/FuelTypes/GetFuelType/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<FuelType>> GetFuelType(int id)
        {
            var fuelType = await _context.FuelTypes.FindAsync(id);

            if (fuelType == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new FuelType
                {
                    FuelTypeId = fuelType.FuelTypeId,
                    FuelName = fuelType.FuelName
                });
            }

            
        }

       
    }
}
