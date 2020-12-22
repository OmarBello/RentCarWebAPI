using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarWebAPI.Helpers
{
    public class UpdateCustomerViewModel
    {
        public int CustomerId { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        [StringLength(30)]
        [MinLength(3, ErrorMessage = "Your name cannot be less than 3 characters")]
        [MaxLength(30, ErrorMessage = "Your name cannot be more than 30 characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        [MinLength(3, ErrorMessage = "Your last name cannot be less than 3 characters")]
        [MaxLength(30, ErrorMessage = "Your last name cannot be more than 30 characters")]
        public string LastName { get; set; }
        [Required]
        [StringLength(30)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]

        public string Username { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        public bool act_password { get; set; }
    }
}
