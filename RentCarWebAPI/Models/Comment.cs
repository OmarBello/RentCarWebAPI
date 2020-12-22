using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RentCarWebAPI.Models
{
    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfComment { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Comments")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(VehicleId))]
        [InverseProperty("Comments")]
        public virtual Vehicle Vehicle { get; set; }
    }
}
