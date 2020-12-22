using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RentCarWebAPI.Models
{
    [Table("VehicleType")]
    public partial class VehicleType
    {
        public VehicleType()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        public int VehcileTypeId { get; set; }
        [Required]
        [StringLength(30)]
        public string TypeName { get; set; }

        [InverseProperty(nameof(Vehicle.VehicleType))]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
