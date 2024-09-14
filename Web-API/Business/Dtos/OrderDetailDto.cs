namespace Business.Dtos
{
    public class OrderDetailDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public float Discount { get; set; }
    }

}
