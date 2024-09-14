namespace DataAccess.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        // Relationship with Customer (many to 1)
        public int? CustId { get; set; }
        public Customer Customer { get; set; }

        // Relationship with Employee (many to 1)
        public int EmpId { get; set; }
        public Employee Employee { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        // Relationship with Shipper (many to 1)
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; }

        public decimal Freight { get; set; }

        [MaxLength(100)]
        public string ShipName { get; set; }

        [MaxLength(200)]
        public string ShipAddress { get; set; }

        [MaxLength(100)]
        public string ShipCity { get; set; }

        [MaxLength(100)]
        public string ShipRegion { get; set; }

        [MaxLength(20)]
        public string ShipPostalCode { get; set; }

        [MaxLength(100)]
        public string ShipCountry { get; set; }

        // Relationship with OrderDetails (1 to many)
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
