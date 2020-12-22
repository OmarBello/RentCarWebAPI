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
    public class VehiculeModelsController : ControllerBase
    {
        private readonly RentCarContext _context;

        public VehiculeModelsController(RentCarContext context)
        {
            _context = context;
        }

        // GET: api/VehiculeModels/GetVehiculeModels
        [HttpGet("[action]")]
        public async Task<IEnumerable<VehicleModelViewModel>> GetVehiculeModel()
        {
            var vehiculeModel = await _context.VehiculeModels.Include(a => a.Manufacturer).ToListAsync();

            return vehiculeModel.Select(a => new VehicleModelViewModel
            {
                VehiculeModelId = a.VehiculeModelId,
                ManufacturerId = a.ManufacturerId,
                ManufacturerName = a.Manufacturer.ManufacturerName,
                ModelName = a.ModelName,
                Description = a.Description

            });

            //return await _context.VehiculeModels.ToArrayAsync();


        }

        // GET: api/VehiculeModels/GetVehiculeModel/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<VehiculeModel>> GetVehiculeModel([FromRoute]int id)
        {
            var vehiculeModel = await _context.VehiculeModels.Include(a => a.Manufacturer).
                SingleOrDefaultAsync(a => a.VehiculeModelId == id);

            if (vehiculeModel == null)
            {
                return NotFound();
            }

            return Ok(new VehicleModelViewModel
            {
                VehiculeModelId = vehiculeModel.VehiculeModelId,
                ManufacturerId = vehiculeModel.ManufacturerId,
                ManufacturerName = vehiculeModel.Manufacturer.ManufacturerName,
                ModelName = vehiculeModel.ModelName,
                Description = vehiculeModel.Description
            });
            
        }

        // PUT: api/VehiculeModels/PutVehiculeModel/
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]")]
        public async Task<IActionResult> PutVehiculeModel([FromBody] UpdateVehicleModelViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(model.VehiculeModelId <= 0)
            {
                return BadRequest();
            }

            var vehicleModel = await _context.VehiculeModels.FirstOrDefaultAsync(a => a.VehiculeModelId == model.VehiculeModelId);

            if(vehicleModel == null)
            {
                return NotFound();
            }

            vehicleModel.ManufacturerId = model.ManufacturerId;
            vehicleModel.ModelName = model.ModelName;
            vehicleModel.Description = model.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();

        }

        // POST: api/VehiculeModels/PostVehiculeModel
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<IActionResult> PostVehiculeModel([FromBody] CreateVehicleModelViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            VehiculeModel vehiculeModel = new VehiculeModel
            {
                ManufacturerId = model.ManufacturerId,
                ModelName = model.ModelName,
                Description = model.Description

            };

            _context.VehiculeModels.Add(vehiculeModel);
            try
            {
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        // DELETE: api/VehiculeModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehiculeModel>> DeleteVehiculeModel(int id)
        {
            var vehiculeModel = await _context.VehiculeModels.FindAsync(id);
            if (vehiculeModel == null)
            {
                return NotFound();
            }

            _context.VehiculeModels.Remove(vehiculeModel);
            await _context.SaveChangesAsync();

            return vehiculeModel;
        }

        private bool VehiculeModelExists(int id)
        {
            return _context.VehiculeModels.Any(e => e.VehiculeModelId == id);
        }
    }
}
