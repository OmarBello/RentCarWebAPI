using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RentCarWebAPI.Models
{
    [Table("VehiculeModel")]
    public partial class VehiculeModel
    {
        public VehiculeModel()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        public int VehiculeModelId { get; set; }
        public int ManufacturerId { get; set; }
        [Required]
        [StringLength(30)]
        public string ModelName { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        [InverseProperty("VehiculeModels")]
        public virtual Manufacturer Manufacturer { get; set; }
        [InverseProperty(nameof(Vehicle.VehicleModel))]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
