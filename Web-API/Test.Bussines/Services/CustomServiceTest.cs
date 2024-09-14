namespace Test.Bussines.Services
{
    using AutoMapper;
    using Business.Dtos;
    using Business.Services.Imp;
    using DataAccess.Models;
    using DataAccess.Repositories;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [TestFixture]
    public class CustomServiceTest
    {
        private Mock<ICustomRepository> mockCustomRepository;
        private Mock<IRepository<Order>> mockOrderRepository;
        private Mock<IMapper> mockMapper;
        private CustomService service;

        [SetUp]
        public void Setup()
        {
            // Setup the mocks
            mockCustomRepository = new Mock<ICustomRepository>();
            mockOrderRepository = new Mock<IRepository<Order>>();
            mockMapper = new Mock<IMapper>();

            // Instantiate the service with the mocked dependencies
            service = new CustomService(mockCustomRepository.Object, mockOrderRepository.Object, mockMapper.Object);
        }

        [Test]
        public async Task GetOrdersByCustomerIdShouldReturnOrderDtos()
        {
            // Arrange
            var orders = new List<Order> { new Order { } };
            var orderDtos = new List<OrderDto> { new OrderDto {  } };

            mockCustomRepository.Setup(repo => repo.GetOrdersByCustomerId(It.IsAny<int>())).ReturnsAsync(orders);
            mockMapper.Setup(mapper => mapper.Map<IEnumerable<OrderDto>>(orders)).Returns(orderDtos);

            // Act
            var result = await service.GetOrdersByCustomerId(1);

            // Assert
            Assert.AreEqual(orderDtos, result);
            mockCustomRepository.Verify(repo => repo.GetOrdersByCustomerId(1), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<IEnumerable<OrderDto>>(orders), Times.Once);
        }

        [Test]
        public async Task GetSalesDatePredictionShouldReturnCustomerOrderPredictionDtos()
        {
            // Arrange
            var orders = new List<CustomerOrderPrediction> { new CustomerOrderPrediction {  } };
            var predictionDtos = new List<CustomerOrderPredictionDto> { new CustomerOrderPredictionDto { } };

            mockCustomRepository.Setup(repo => repo.GetSalesDatePrediction()).ReturnsAsync(orders);
            mockMapper.Setup(mapper => mapper.Map<IEnumerable<CustomerOrderPredictionDto>>(orders)).Returns(predictionDtos);

            // Act
            var result = await service.GetSalesDatePrediction();

            // Assert
            Assert.AreEqual(predictionDtos, result);
            mockCustomRepository.Verify(repo => repo.GetSalesDatePrediction(), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<IEnumerable<CustomerOrderPredictionDto>>(orders), Times.Once);
        }

        [Test]
        public async Task CreateOrderAsyncShouldCallCreateOrderAsyncOnRepository()
        {
            // Arrange
            var createOrderDto = new CreateOrderDto
            {
                EmpId = 1,
                ShipperId = 2,
                ShipName = "John Doe",
                ShipAddress = "123 Shipping St.",
                ShipCity = "New York",
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(7),
                ShippedDate = null,
                Freight = 50.00M,
                ShipCountry = "USA",
                ProductId = 59,
                UnitPrice = 20.00M,
                Qty = 5,
                Discount = 0.10F
            };

            var order = new Order
            {
                EmpId = createOrderDto.EmpId,
                ShipperId = createOrderDto.ShipperId,
                ShipName = createOrderDto.ShipName,
                ShipAddress = createOrderDto.ShipAddress,
                ShipCity = createOrderDto.ShipCity,
                OrderDate = createOrderDto.OrderDate,
                RequiredDate = createOrderDto.RequiredDate,
                ShippedDate = createOrderDto.ShippedDate,
                Freight = createOrderDto.Freight,
                ShipCountry = createOrderDto.ShipCountry
            };

            var orderDetail = new OrderDetail
            {
                ProductId = createOrderDto.ProductId,
                UnitPrice = createOrderDto.UnitPrice,
                Qty = createOrderDto.Qty,
                Discount = createOrderDto.Discount
            };

            mockMapper.Setup(mapper => mapper.Map<Order>(createOrderDto)).Returns(order);

            // Act
            await service.CreateOrderAsync(createOrderDto);

            // Assert
            mockCustomRepository.Verify(repo => repo.CreateOrderAsync(It.IsAny<Order>(), It.IsAny<OrderDetail>()), Times.Once);
        }
    }
}
