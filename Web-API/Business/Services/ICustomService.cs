namespace Business.Services
{
    using Business.Dtos;
    using DataAccess.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICustomService
    {
        Task<IEnumerable<CustomerOrderPredictionDto>> GetSalesDatePrediction();
        Task<IEnumerable<OrderDto>> GetOrdersByCustomerId(int id);
        Task CreateOrderAsync(CreateOrderDto createOrderDto);
    }
}
