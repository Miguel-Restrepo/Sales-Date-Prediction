namespace Business.Mappers
{
    using AutoMapper;
    using Business.Dtos;
    using DataAccess.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Shipper, ShipperDto>();
            CreateMap<CustomerOrderPrediction, CustomerOrderPredictionDto>();
        }
    }

}
