using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RentCarWebAPI.Models
{
    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            Comments = new HashSet<Comment>();
        }

        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("CustomerTypeID")]
        public int CustomerTypeId { get; set; }
        [Column("CityID")]
        public int CityId { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [StringLength(30)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Customers")]
        public virtual City City { get; set; }
        [ForeignKey(nameof(CustomerTypeId))]
        [InverseProperty("Customers")]
        public virtual CustomerType CustomerType { get; set; }
        [InverseProperty(nameof(Booking.Customer))]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty(nameof(Comment.Customer))]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
