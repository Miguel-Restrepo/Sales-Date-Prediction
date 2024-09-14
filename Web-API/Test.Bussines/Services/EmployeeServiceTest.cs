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
    public class EmployeeServiceTest
    {
        private Mock<IRepository<Employee>> mockRepository;
        private Mock<IMapper> mockMapper;
        private EmployeeService service;

        [SetUp]
        public void Setup()
        {
            // Setup the mocks
            mockRepository = new Mock<IRepository<Employee>>();
            mockMapper = new Mock<IMapper>();

            // Instantiate the service with the mocked dependencies
            service = new EmployeeService(mockRepository.Object, mockMapper.Object);
        }

        [Test]
        public async Task GetAllShouldReturnEmployeeDtos()
        {
            // Arrange
            var employees = new List<Employee> { new Employee { } };
            var employeeDtos = new List<EmployeeDto> { new EmployeeDto { } };

            mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(employees);
            mockMapper.Setup(mapper => mapper.Map<IEnumerable<EmployeeDto>>(employees)).Returns(employeeDtos);

            // Act
            var result = await service.GetAll();

            // Assert
            Assert.AreEqual(employeeDtos, result);
            mockRepository.Verify(repo => repo.GetAll(), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<IEnumerable<EmployeeDto>>(employees), Times.Once);
        }

        [Test]
        public async Task GetByIdShouldReturnEmployeeDto()
        {
            // Arrange
            var employee = new Employee { };
            var employeeDto = new EmployeeDto { };

            mockRepository.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(employee);
            mockMapper.Setup(mapper => mapper.Map<EmployeeDto>(employee)).Returns(employeeDto);

            // Act
            var result = await service.GetById(1);

            // Assert
            Assert.AreEqual(employeeDto, result);
            mockRepository.Verify(repo => repo.GetById(1), Times.Once);
            mockMapper.Verify(mapper => mapper.Map<EmployeeDto>(employee), Times.Once);
        }

        [Test]
        public async Task AddShouldCallRepositoryAdd()
        {
            // Arrange
            var employeeDto = new EmployeeDto { };
            var employee = new Employee { };

            mockMapper.Setup(mapper => mapper.Map<Employee>(employeeDto)).Returns(employee);

            // Act
            await service.Add(employeeDto);

            // Assert
            mockRepository.Verify(repo => repo.Add(employee), Times.Once);
        }

        [Test]
        public async Task UpdateShouldCallRepositoryUpdate()
        {
            // Arrange
            var employeeDto = new EmployeeDto { };
            var employee = new Employee { };

            mockMapper.Setup(mapper => mapper.Map<Employee>(employeeDto)).Returns(employee);

            // Act
            await service.Update(employeeDto);

            // Assert
            mockRepository.Verify(repo => repo.Update(employee), Times.Once);
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
