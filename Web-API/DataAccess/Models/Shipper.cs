namespace DataAccess.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Shipper
    {
        [Key]
        public int ShipperId { get; set; }

        [Required, MaxLength(100)]
        public string CompanyName { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        // Relationship with Order (1 to many)
        public ICollection<Order> Orders { get; set; }
    }
}
