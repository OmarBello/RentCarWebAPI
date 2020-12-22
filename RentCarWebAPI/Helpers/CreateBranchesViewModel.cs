using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarWebAPI.Helpers
{
    public class CreateBranchesViewModel
    {
        [Column("CityID")]
        public int CityId { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(3, ErrorMessage = "Your business / place name cannot be less than 3 characters long")]
        [MaxLength(50, ErrorMessage = "The name of your business / place cannot be more than 50 characters")]
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
    }
}
