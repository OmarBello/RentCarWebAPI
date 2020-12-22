using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RentCarWebAPI.Models
{
    [Table("FuelType")]
    public partial class FuelType
    {
        public FuelType()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        public int FuelTypeId { get; set; }
        [Required]
        [StringLength(30)]
        public string FuelName { get; set; }

        [InverseProperty(nameof(Vehicle.FuelType))]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
