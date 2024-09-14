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
    public class ProductServiceTest
    {
        private Mock<IRepository<Product>> mockRepository;
        private Mock<IMapper> mockMapper;
        private ProductService service;

        [SetUp]
        public void Setup()
        {
            // Setup the mocks
            mockRepository = new Mock<IRepository<Product>>();
            mockMapper = new Mock<IMapper>();

            // Instantiate the service with the mocked dependencies
            service = new ProductService(mockRepository.Object, mockMapper.Object);
        }

        [Test]
        public async Task GetAllShouldReturnProductDtos()
        {
            // Arrange
            var products = new List<Product> { new Product { } };
            var productDtos = new List<ProductDto> { new ProductDto { } };

            mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(products);
            mockMapper.Setup(mapper => mapper.Map<IEnumerable<ProductDto>>(products)).Returns(productDtos);

            // Act
            var result = await service.GetAll();

            // Assert
            Assert.AreEqual(productDtos, result);
            mockRepository.Verify(repo => repo.GetAll(), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<IEnumerable<ProductDto>>(products), Times.Once);
        }

        [Test]
        public async Task GetByIdShouldReturnProductDto()
        {
            // Arrange
            var product = new Product { };
            var productDto = new ProductDto { };

            mockRepository.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(product);
            mockMapper.Setup(mapper => mapper.Map<ProductDto>(product)).Returns(productDto);

            // Act
            var result = await service.GetById(1);

            // Assert
            Assert.AreEqual(productDto, result);
            mockRepository.Verify(repo => repo.GetById(1), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<ProductDto>(product), Times.Once);
        }

        [Test]
        public async Task AddShouldCallRepositoryAdd()
        {
            // Arrange
            var productDto = new ProductDto { };
            var product = new Product { };

            mockMapper.Setup(mapper => mapper.Map<Product>(productDto)).Returns(product);

            // Act
            await service.Add(productDto);

            // Assert
            mockRepository.Verify(repo => repo.Add(product), Times.Once);
        }

        [Test]
        public async Task UpdateShouldCallRepositoryUpdate()
        {
            // Arrange
            var productDto = new ProductDto { };
            var product = new Product { };

            mockMapper.Setup(mapper => mapper.Map<Product>(productDto)).Returns(product);

            // Act
            await service.Update(productDto);

            // Assert
            mockRepository.Verify(repo => repo.Update(product), Times.Once);
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
