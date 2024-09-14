namespace DataAccess.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        [Key]
        public int CustId { get; set; }

        [Required, MaxLength(100)]
        public string CompanyName { get; set; }

        [MaxLength(100)]
        public string ContactName { get; set; }

        [MaxLength(100)]
        public string ContactTitle { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string Region { get; set; }

        [MaxLength(20)]
        public string PostalCode { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(20)]
        public string Fax { get; set; }

        // Relationship with Order (1 to many)
        public ICollection<Order> Orders { get; set; }
    }
}