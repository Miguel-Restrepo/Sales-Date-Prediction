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
    public class ShipperServiceTest
    {
        private Mock<IRepository<Shipper>> mockRepository;
        private Mock<IMapper> mockMapper;
        private ShipperService service;

        [SetUp]
        public void Setup()
        {
            // Setup the mocks
            mockRepository = new Mock<IRepository<Shipper>>();
            mockMapper = new Mock<IMapper>();

            // Instantiate the service with the mocked dependencies
            service = new ShipperService(mockRepository.Object, mockMapper.Object);
        }

        [Test]
        public async Task GetAllShouldReturnShipperDtos()
        {
            // Arrange
            var shippers = new List<Shipper> { new Shipper { } };
            var shipperDtos = new List<ShipperDto> { new ShipperDto { } };

            mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(shippers);
            mockMapper.Setup(mapper => mapper.Map<IEnumerable<ShipperDto>>(shippers)).Returns(shipperDtos);

            // Act
            var result = await service.GetAll();

            // Assert
            Assert.AreEqual(shipperDtos, result);
            mockRepository.Verify(repo => repo.GetAll(), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<IEnumerable<ShipperDto>>(shippers), Times.Once);
        }

        [Test]
        public async Task GetByIdShouldReturnShipperDto()
        {
            // Arrange
            var shipper = new Shipper { };
            var shipperDto = new ShipperDto { };

            mockRepository.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(shipper);
            mockMapper.Setup(mapper => mapper.Map<ShipperDto>(shipper)).Returns(shipperDto);

            // Act
            var result = await service.GetById(1);

            // Assert
            Assert.AreEqual(shipperDto, result);
            mockRepository.Verify(repo => repo.GetById(1), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<ShipperDto>(shipper), Times.Once);
        }

        [Test]
        public async Task AddShouldCallRepositoryAdd()
        {
            // Arrange
            var shipperDto = new ShipperDto { };
            var shipper = new Shipper { };

            mockMapper.Setup(mapper => mapper.Map<Shipper>(shipperDto)).Returns(shipper);

            // Act
            await service.Add(shipperDto);

            // Assert
            mockRepository.Verify(repo => repo.Add(shipper), Times.Once);
        }

        [Test]
        public async Task UpdateShouldCallRepositoryUpdate()
        {
            // Arrange
            var shipperDto = new ShipperDto { };
            var shipper = new Shipper { };

            mockMapper.Setup(mapper => mapper.Map<Shipper>(shipperDto)).Returns(shipper);

            // Act
            await service.Update(shipperDto);

            // Assert
            mockRepository.Verify(repo => repo.Update(shipper), Times.Once);
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
