using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarWebAPI.Helpers
{
    public class VehicleViewModel
    {
        //Cabecera
        public int VehicleId { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int FuelTypeId { get; set; }
        public string FuelName { get; set; }
        public int VehicleTypeId { get; set; }
        public string TypeName { get; set; }

        public int VehicleModelId { get; set; }
        public string ModelName { get; set; }
        public byte[] Image { get; set; }
        public int VehicleNumber { get; set; }
   
        public decimal DailyPrice { get; set; }
      
        public string Description { get; set; }
        public int NumberOfSeats { get; set; }
 
        public string Transmission { get; set; }
        public bool? Status { get; set; }
    }
}
