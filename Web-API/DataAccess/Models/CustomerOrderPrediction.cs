namespace DataAccess.Models
{
    using System;

    public class CustomerOrderPrediction
    {
        public string CompanyName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
