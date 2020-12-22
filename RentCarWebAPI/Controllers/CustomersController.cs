using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RentCarWebAPI.Helpers;
using RentCarWebAPI.Models;

namespace RentCarWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly RentCarContext _context;
        private readonly IConfiguration _config;

        public CustomersController(RentCarContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: api/Customers/GetCustomer
        [HttpGet("[action]")]
        public async Task<IEnumerable<CustomerViewModel>> GetCustomer()
        {
            var user = await _context.Customers.Include(u => u.City).ToListAsync();

            return user.Select(u => new CustomerViewModel
            {
              CustomerId = u.CustomerId,
              CityId = u.CityId,
              CityName = u.City.CityName,
              FirstName = u.FirstName,
              LastName = u.LastName,
              Phone = u.Phone,
              Email = u.Email,
              Username = u.Username,
              PasswordHash = u.PasswordHash

            });

            //return await _context.VehiculeModels.ToArrayAsync();


        }

        // POST: api/Customers/PostCustomer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<IActionResult> PostCustomer([FromBody] CreateCustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var email = model.Email.ToLower();
            var userName = model.Username;

            if(await _context.Customers.AnyAsync(u => u.Email == email) && await _context.Customers.AnyAsync(u => u.Username == userName))
            {
                return BadRequest("User and Email already exist");
            }

            CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
            Customer customer = new Customer
            {
              CityId = model.CityId,
              FirstName = model.FirstName,
              LastName = model.LastName,
              Phone = model.Phone,
              Email = model.Email.ToLower(),
              Username = model.Username,
              PasswordHash = passwordHash,
              PasswordSalt = passwordSalt

            };

            _context.Customers.Add(customer);
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

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        // PUT: api/Customers/PutCustomer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]")]
        public async Task<IActionResult> PutCustomer([FromBody] UpdateCustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.CustomerId <= 0)
            {
                return BadRequest();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(a => a.CustomerId == model.CustomerId);

            if (customer == null)
            {
                return NotFound();
            }

            customer.CityId = model.CityId;
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.Phone = model.Phone;
            customer.Email = model.Email;
            customer.Username = model.Username;
            
            //Si es necesario o no actualizar el password
            if(model.act_password == true)
            {
                CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
                customer.PasswordHash = passwordHash;
                customer.PasswordSalt = passwordSalt;
            }

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

        //POST: api/Customers/Login
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var email = model.Email.ToLower();

            var usuario = await _context.Customers.FirstOrDefaultAsync(u => u.Email == email);

            if(usuario == null)
            {
                return NotFound();
            }

            if (VerificarPasswordHash(model.Password, usuario.PasswordHash, usuario.PasswordSalt))
            {
                return NotFound();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.CustomerId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim("CustomerID", usuario.CustomerId.ToString()),
                new Claim("nombre", usuario.FirstName)
            };

            return Ok(
                 new {token = GenerarToken(claims)}
                );

        }

        

        private bool VerificarPasswordHash(string password, byte[] passwordHasAlmacenado, byte[] passwordSalt)
        {
             using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passwordHashNuevo = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return new ReadOnlySpan<byte>(passwordHasAlmacenado).SequenceEqual(new ReadOnlySpan<byte>(passwordHashNuevo));
            }
        }

        private string GenerarToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds,
                claims: claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
