using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarWebAPI.Helpers
{
    public class VehicleCreateViewModel
    {
        [Required]
        public int BranchId { get; set; }
        [Required]
        public int FuelTypeId { get; set; }
        [Required]
        public int VehicleTypeId { get; set; }
        [Required]
        public int VehicleModelId { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public int VehicleNumber { get; set; }
        [Required]

        public decimal DailyPrice { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        [Required]

        public string Transmission { get; set; }
    }
}
