using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarWebAPI.Helpers
{
    public class BranchesViewModel
    {
     
        public int BranchId { get; set; }
 
        public int CityId { get; set; }
        public string CityName { get; set; }

        public string BranchName { get; set; }
   
        public string PhoneNumber { get; set; }
    
        public string Adress { get; set; }
   
        public string OpenTime { get; set; }
      
        public string CloseTime { get; set; }
       
        public string Description { get; set; }
    }
}
