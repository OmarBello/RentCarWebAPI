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
    public class VehicleTypesController : ControllerBase
    {
        private readonly RentCarContext _context;

        public VehicleTypesController(RentCarContext context)
        {
            _context = context;
        }

       

        // GET: api/VehicleTypes/GetVehicleTypes
        [HttpGet("[action]")]
        public async Task<IEnumerable<VehicleType>> GetVehicleTypes()
        {
            var vehicleTypes = await _context.VehicleTypes.ToListAsync();
            return vehicleTypes.Select(c => new VehicleType
            {
                VehcileTypeId = c.VehcileTypeId,
                TypeName = c.TypeName
            });
        }

        // GET: api/VehicleTypes/GetVehicleType/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<VehicleType>> GetVehicleType([FromRoute] int id)
        {

            var vehicleType = await _context.VehicleTypes.FindAsync(id);

            if (vehicleType == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new VehicleType
                {
                    VehcileTypeId = vehicleType.VehcileTypeId,
                    TypeName = vehicleType.TypeName
                });
            }


        }


    }
}

