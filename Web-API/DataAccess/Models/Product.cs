namespace DataAccess.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, MaxLength(100)]
        public string ProductName { get; set; }

        public int SupplierId { get; set; }
        public int CategoryId { get; set; }

        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }

        // Relationship with OrderDetails (1 to many)
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
