using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RentCarWebAPI.Models
{
    [Table("Manufacturer")]
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            VehiculeModels = new HashSet<VehiculeModel>();
        }

        [Key]
        public int ManufacturerId { get; set; }
        [Required]
        [StringLength(30)]
        public string ManufacturerName { get; set; }

        [InverseProperty(nameof(VehiculeModel.Manufacturer))]
        public virtual ICollection<VehiculeModel> VehiculeModels { get; set; }
    }
}
