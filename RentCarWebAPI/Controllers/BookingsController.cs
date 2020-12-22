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
    public class BookingsController : ControllerBase
    {
        private readonly RentCarContext _context;

        public BookingsController(RentCarContext context)
        {
            _context = context;
        }

        // GET: api/Bookings/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<BookingViewModel>> Listar()
        {
            var booking = await _context.Bookings
                .Include(c => c.Customer)
                .Include(v => v.Vehicle)
                .ToListAsync();

            return booking.Select(b => new BookingViewModel
            {
                BookingId = b.BookingId,
                CustomerId = b.Customer.CustomerId,
                FirstName = b.Customer.FirstName,
                VehicleId = b.Vehicle.VehicleId,
                VehicleNumber = b.Vehicle.VehicleNumber,
                StartDate = b.StartDate,
                EndDate = b.EndDate
            });
        }

        // POST: api/Bookings/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] BookingCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var startHora = DateTime.Now;
           

            Booking booking = new Booking
            {
                CustomerId = model.CustomerId,
                VehicleId = model.VehicleId,
                StartDate = startHora,
                EndDate = model.EndDate
            };

            try
            {
                _context.Bookings.Add(booking);
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
