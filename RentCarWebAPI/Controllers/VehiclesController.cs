using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarWebAPI.Helpers;
using RentCarWebAPI.Models;

namespace RentCarWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly RentCarContext _context;

        public VehiclesController(RentCarContext context)
        {
            _context = context;
        }

        // GET: api/Vehicles/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<VehicleViewModel>> Listar()
        {
            var vehicle = await _context.Vehicles
                .Include(b => b.Branch)
                .Include(v => v.VehicleModel)
                .Include(f => f.FuelType)
                .Include(v => v.VehicleType)
                .OrderByDescending(v => v.VehicleId)
                .Take(100)
                .ToListAsync();

            return vehicle.Select(v => new VehicleViewModel
            {
                VehicleId = v.VehicleId,
                BranchId = v.Branch.BranchId,
                BranchName = v.Branch.BranchName,
                VehicleModelId = v.VehicleModel.VehiculeModelId,
                ModelName = v.VehicleModel.ModelName,
                FuelTypeId = v.FuelType.FuelTypeId,
                FuelName = v.FuelType.FuelName,
                VehicleTypeId = v.VehicleType.VehcileTypeId,
                TypeName = v.VehicleType.TypeName,
                Image = v.Image,
                VehicleNumber = v.VehicleNumber,
                DailyPrice = v.DailyPrice,
                Description = v.Description,
                NumberOfSeats = v.NumberOfSeats,
                Transmission = v.Transmission,
                Status = v.Status
            });
        }
    



        // POST: api/Vehicles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] VehicleCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Vehicle vehicle = new Vehicle {
                BranchId = model.BranchId,
                FuelTypeId = model.BranchId,
                VehicleTypeId = model.VehicleTypeId,
                VehicleModelId = model.VehicleModelId,
                Image = model.Image,
                VehicleNumber = model.VehicleNumber,
                DailyPrice = model.DailyPrice,
                Description = model.Description,
                NumberOfSeats = model.NumberOfSeats,
                Transmission = model.Transmission,
                Status = true
            };

            try
            {
                _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }
    

    }
}
