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
    public class CustomerServiceTests
    {
        private Mock<IRepository<Customer>> mockRepository;
        private Mock<IMapper> mockMapper;
        private CustomerService service;

        [SetUp]
        public void Setup()
        {
            // Setup the mocks
            mockRepository = new Mock<IRepository<Customer>>();
            mockMapper = new Mock<IMapper>();

            // Instantiate the service with the mocked dependencies
            service = new CustomerService(mockRepository.Object, mockMapper.Object);
        }

        [Test]
        public async Task GetAllShouldReturnCustomerDtos()
        {
            // Arrange
            var customers = new List<Customer> { new Customer {} };
            var customerDtos = new List<CustomerDto> { new CustomerDto {} };

            mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(customers);
            mockMapper.Setup(mapper => mapper.Map<IEnumerable<CustomerDto>>(customers)).Returns(customerDtos);

            // Act
            var result = await service.GetAll();

            // Assert
            Assert.AreEqual(customerDtos, result);
            mockRepository.Verify(repo => repo.GetAll(), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<IEnumerable<CustomerDto>>(customers), Times.Once);
        }

        [Test]
        public async Task GetByIdShouldReturnCustomerDto()
        {
            // Arrange
            var customer = new Customer {  };
            var customerDto = new CustomerDto {  };

            mockRepository.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(customer);
            mockMapper.Setup(mapper => mapper.Map<CustomerDto>(customer)).Returns(customerDto);

            // Act
            var result = await service.GetById(1);

            // Assert
            Assert.AreEqual(customerDto, result);
            mockRepository.Verify(repo => repo.GetById(1), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<CustomerDto>(customer), Times.Once);
        }

        [Test]
        public async Task AddShouldCallRepositoryAdd()
        {
            // Arrange
            var customerDto = new CustomerDto { };
            var customer = new Customer { };

            mockMapper.Setup(mapper => mapper.Map<Customer>(customerDto)).Returns(customer);

            // Act
            await service.Add(customerDto);

            // Assert
            mockRepository.Verify(repo => repo.Add(customer), Times.Once);
        }

        [Test]
        public async Task UpdateShouldCallRepositoryUpdate()
        {
            // Arrange
            var customerDto = new CustomerDto {  };
            var customer = new Customer { };

            mockMapper.Setup(mapper => mapper.Map<Customer>(customerDto)).Returns(customer);

            // Act
            await service.Update(customerDto);

            // Assert
            mockRepository.Verify(repo => repo.Update(customer), Times.Once);
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
