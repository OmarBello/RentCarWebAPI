using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RentCarWebAPI.Models
{
    [Table("CustomerType")]
    public partial class CustomerType
    {
        public CustomerType()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        [Column("CustomerTypeID")]
        public int CustomerTypeId { get; set; }
        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        [InverseProperty(nameof(Customer.CustomerType))]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
