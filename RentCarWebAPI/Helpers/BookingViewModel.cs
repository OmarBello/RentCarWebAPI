using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarWebAPI.Helpers
{
    public class BookingViewModel
    {
      
        public int BookingId { get; set; }

        public int CustomerId { get; set; }

        public string FirstName { get; set; }
   
        public int VehicleId { get; set; }
        public int VehicleNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
