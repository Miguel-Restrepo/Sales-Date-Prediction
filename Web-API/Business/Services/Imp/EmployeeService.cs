namespace Business.Services.Imp
{
    using AutoMapper;
    using Business.Dtos;
    using DataAccess.Models;
    using DataAccess.Repositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EmployeeService : IService<EmployeeDto>
    {
        private readonly IRepository<Employee> repository;
        private readonly IMapper mapper;

        public EmployeeService(IRepository<Employee> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            var employees = await this.repository.GetAll();
            return this.mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetById(int id)
        {
            var employee = await this.repository.GetById(id);
            return this.mapper.Map<EmployeeDto>(employee);
        }

        public async Task Add(EmployeeDto employeeDTO)
        {
            var employee = this.mapper.Map<Employee>(employeeDTO);
            await this.repository.Add(employee);
        }

        public async Task Update(EmployeeDto employeeDTO)
        {
            var employee = this.mapper.Map<Employee>(employeeDTO);
            await this.repository.Update(employee);
        }

        public async Task Delete(int id)
        {
            await this.repository.Delete(id);
        }
    }
}
