namespace Business.Dtos
{
    using System;

    public class CustomerOrderPredictionDto
    {
        public int CustId { get; set; }
        public string CompanyName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
