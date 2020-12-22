using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RentCarWebAPI.Models
{
    [Table("Branch")]
    public partial class Branch
    {
        public Branch()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        [Column("BranchID")]
        public int BranchId { get; set; }
        [Column("CityID")]
        public int CityId { get; set; }
        [Required]
        [StringLength(50)]
        public string BranchName { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string Adress { get; set; }
        [StringLength(20)]
        public string OpenTime { get; set; }
        [StringLength(20)]
        public string CloseTime { get; set; }
        [StringLength(50)]
        public string Description { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Branches")]
        public virtual City City { get; set; }
        [InverseProperty(nameof(Vehicle.Branch))]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
