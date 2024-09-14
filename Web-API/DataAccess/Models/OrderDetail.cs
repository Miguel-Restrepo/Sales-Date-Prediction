namespace DataAccess.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Key]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public float Discount { get; set; }
    }
}