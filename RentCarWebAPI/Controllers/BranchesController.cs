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
    public class BranchesController : ControllerBase
    {
        private readonly RentCarContext _context;

        public BranchesController(RentCarContext context)
        {
            _context = context;
        }

        // GET: api/Branches/GetBranches
        [HttpGet("[action]")]
        public async Task<IEnumerable<BranchesViewModel>> GetBranches()
        {
            var branch = await _context.Branches.Include(b => b.City).ToListAsync();

            return branch.Select(b => new BranchesViewModel
            {
               BranchId = b.BranchId,
               CityId = b.CityId,
               CityName = b.City.CityName,
               BranchName = b.BranchName,
               PhoneNumber = b.PhoneNumber,
               Adress = b.Adress,
               OpenTime = b.OpenTime,
               CloseTime = b.CloseTime,
               Description = b.Description

            });

            //return await _context.VehiculeModels.ToArrayAsync();


        }
        // GET: api/Branches/GetBranch/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<BranchesViewModel>> GetBranch([FromRoute] int id)
        {
            var branch = await _context.Branches.Include(a => a.City).
                SingleOrDefaultAsync(a => a.BranchId == id);

            if (branch == null)
            {
                return NotFound();
            }

            return Ok(new BranchesViewModel
            {
                BranchId = branch.BranchId,
                CityId = branch.CityId,
                CityName = branch.City.CityName,
                BranchName = branch.BranchName,
                PhoneNumber = branch.PhoneNumber,
                Adress = branch.Adress,
                OpenTime = branch.OpenTime,
                CloseTime = branch.CloseTime,
                Description = branch.Description
            });

        }

        // PUT: api/Branches/PutBranches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]")]
        public async Task<IActionResult> PutBranches([FromBody] UpdateBranchesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.BranchId <= 0)
            {
                return BadRequest();
            }

            var branch = await _context.Branches.FirstOrDefaultAsync(b => b.BranchId == model.BranchId);

            if (branch == null)
            {
                return NotFound();
            }

            branch.CityId = model.CityId;
            branch.BranchName = model.BranchName;
            branch.PhoneNumber = model.PhoneNumber;
            branch.Adress = model.Adress;
            branch.OpenTime = model.OpenTime;
            branch.CloseTime = model.CloseTime;
            branch.Description = model.Description;

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

        // POST: api/Branches/PostBranches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<IActionResult> PostBranches([FromBody] CreateBranchesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Branch branch = new Branch
            {
                CityId = model.CityId,
                BranchName = model.BranchName,
                PhoneNumber = model.PhoneNumber,
                Adress = model.Adress,
                OpenTime = model.OpenTime,
                CloseTime = model.CloseTime,
                Description = model.Description

            };

            _context.Branches.Add(branch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Branch>> DeleteBranch(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();

            return branch;
        }

        private bool BranchExists(int id)
        {
            return _context.Branches.Any(e => e.BranchId == id);
        }
    }
}
