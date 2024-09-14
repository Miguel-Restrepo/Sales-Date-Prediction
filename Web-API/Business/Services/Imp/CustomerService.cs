namespace Business.Services.Imp
{
    using AutoMapper;
    using Business.Dtos;
    using DataAccess.Models;
    using DataAccess.Repositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CustomerService : IService<CustomerDto>
    {
        private readonly IRepository<Customer> repository;
        private readonly IMapper mapper;

        public CustomerService(IRepository<Customer> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            var customers = await this.repository.GetAll();
            return this.mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetById(int id)
        {
            var customer = await this.repository.GetById(id);
            return this.mapper.Map<CustomerDto>(customer);
        }

        public async Task Add(CustomerDto customerDTO)
        {
            var customer = this.mapper.Map<Customer>(customerDTO);
            await this.repository.Add(customer);
        }

        public async Task Update(CustomerDto customerDTO)
        {
            var customer = this.mapper.Map<Customer>(customerDTO);
            await this.repository.Update(customer);
        }

        public async Task Delete(int id)
        {
            await this.repository.Delete(id);
        }
    }
}
