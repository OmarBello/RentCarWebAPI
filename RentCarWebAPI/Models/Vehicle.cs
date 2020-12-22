using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RentCarWebAPI.Models
{
    [Table("Vehicle")]
    public partial class Vehicle
    {
        public Vehicle()
        {
            Bookings = new HashSet<Booking>();
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int VehicleId { get; set; }
        public int BranchId { get; set; }
        public int FuelTypeId { get; set; }
        public int VehicleTypeId { get; set; }
        public int VehicleModelId { get; set; }
        [Required]
        [MaxLength(1)]
        public byte[] Image { get; set; }
        public int VehicleNumber { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal DailyPrice { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int NumberOfSeats { get; set; }
        [Required]
        [StringLength(10)]
        public string Transmission { get; set; }
        public bool? Status { get; set; }

        [ForeignKey(nameof(BranchId))]
        [InverseProperty("Vehicles")]
        public virtual Branch Branch { get; set; }
        [ForeignKey(nameof(FuelTypeId))]
        [InverseProperty("Vehicles")]
        public virtual FuelType FuelType { get; set; }
        [ForeignKey(nameof(VehicleModelId))]
        [InverseProperty(nameof(VehiculeModel.Vehicles))]
        public virtual VehiculeModel VehicleModel { get; set; }
        [ForeignKey(nameof(VehicleTypeId))]
        [InverseProperty("Vehicles")]
        public virtual VehicleType VehicleType { get; set; }
        [InverseProperty(nameof(Booking.Vehicle))]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty(nameof(Comment.Vehicle))]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
