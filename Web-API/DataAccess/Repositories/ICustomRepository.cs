namespace DataAccess.Repositories
{
    using DataAccess.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICustomRepository
    {
        Task<IEnumerable<CustomerOrderPrediction>> GetSalesDatePrediction();
        Task<IEnumerable<Order>> GetOrdersByCustomerId(int id);
        Task CreateOrderAsync(Order order, OrderDetail orderDetails);
    }
}
