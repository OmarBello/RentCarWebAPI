using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RentCarWebAPI.Models
{
    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Bookings")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(VehicleId))]
        [InverseProperty("Bookings")]
        public virtual Vehicle Vehicle { get; set; }
    }
}
