using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarWebAPI.Helpers
{
    public class CreateVehicleModelViewModel
    {
        [Key]
        public int VehiculeModelId { get; set; }
        public int ManufacturerId { get; set; }
        [Required(ErrorMessage = "Model Name is required")]
        [MinLength(3, ErrorMessage = "The model name of the car must be at least 3 characters")]
        [MaxLength(30, ErrorMessage = "The car model name cannot exceed 30 characters")]
        [StringLength(30)]
        public string ModelName { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(3, ErrorMessage = "The Description of the car must be at least 3 characters")]
        [MaxLength(50, ErrorMessage = "The Description car model name cannot exceed 30 characters")]
        public string Description { get; set; }
    }
}
