using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RentCarWebAPI.Models
{
    [Table("City")]
    public partial class City
    {
        public City()
        {
            Branches = new HashSet<Branch>();
            Customers = new HashSet<Customer>();
        }

        [Key]
        [Column("CityID")]
        public int CityId { get; set; }
        [Required]
        [StringLength(50)]
        public string CityName { get; set; }
        [StringLength(50)]
        public string PostCode { get; set; }

        [InverseProperty(nameof(Branch.City))]
        public virtual ICollection<Branch> Branches { get; set; }
        [InverseProperty(nameof(Customer.City))]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
