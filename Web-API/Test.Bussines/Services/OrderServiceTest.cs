namespace Test.Bussines.Services
{

    using NUnit.Framework;
    using Moq;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Business.Dtos;
    using DataAccess.Models;
    using DataAccess.Repositories;
    using Business.Services.Imp;

    [TestFixture]
    public class OrderServiceTest
    {
        private Mock<IRepository<Order>> mockRepository;
        private Mock<IMapper> mockMapper;
        private OrderService service;

        [SetUp]
        public void Setup()
        {
            // Setup the mocks
            mockRepository = new Mock<IRepository<Order>>();
            mockMapper = new Mock<IMapper>();

            // Instantiate the service with the mocked dependencies
            service = new OrderService(mockRepository.Object, mockMapper.Object);
        }

        [Test]
        public async Task GetAllShouldReturnOrderDtos()
        {
            // Arrange
            var orders = new List<Order> { new Order { } };
            var orderDtos = new List<OrderDto> { new OrderDto { } };

            mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(orders);
            mockMapper.Setup(mapper => mapper.Map<IEnumerable<OrderDto>>(orders)).Returns(orderDtos);

            // Act
            var result = await service.GetAll();

            // Assert
            Assert.AreEqual(orderDtos, result);
            mockRepository.Verify(repo => repo.GetAll(), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<IEnumerable<OrderDto>>(orders), Times.Once);
        }

        [Test]
        public async Task GetByIdShouldReturnOrderDto()
        {
            // Arrange
            var order = new Order { };
            var orderDto = new OrderDto { };

            mockRepository.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(order);
            mockMapper.Setup(mapper => mapper.Map<OrderDto>(order)).Returns(orderDto);

            // Act
            var result = await service.GetById(1);

            // Assert
            Assert.AreEqual(orderDto, result);
            mockRepository.Verify(repo => repo.GetById(1), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<OrderDto>(order), Times.Once);
        }

        [Test]
        public async Task AddShouldCallRepositoryAdd()
        {
            // Arrange
            var orderDto = new OrderDto { };
            var order = new Order { };

            mockMapper.Setup(mapper => mapper.Map<Order>(orderDto)).Returns(order);

            // Act
            await service.Add(orderDto);

            // Assert
            mockRepository.Verify(repo => repo.Add(order), Times.Once);
        }

        [Test]
        public async Task UpdateShouldCallRepositoryUpdate()
        {
            // Arrange
            var orderDto = new OrderDto { };
            var order = new Order { };

            mockMapper.Setup(mapper => mapper.Map<Order>(orderDto)).Returns(order);

            // Act
            await service.Update(orderDto);

            // Assert
            mockRepository.Verify(repo => repo.Update(order), Times.Once);
        }

        [Test]
        public async Task DeleteShouldCallRepositoryDelete()
        {
            // Act
            await service.Delete(1);

            // Assert
            mockRepository.Verify(repo => repo.Delete(1), Times.Once);
        }
    }
}
