﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarWebAPI.Helpers
{
    public class UpdateVehicleModelViewModel
    {
        public int VehiculeModelId { get; set; }
        public int ManufacturerId { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
    }
}
