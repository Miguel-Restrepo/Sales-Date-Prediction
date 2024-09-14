namespace Business.Services.Imp
{
    using AutoMapper;
    using Business.Dtos;
    using DataAccess.Models;
    using DataAccess.Repositories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ShipperService : IService<ShipperDto>
    {
        private readonly IRepository<Shipper> repository;
        private readonly IMapper mapper;

        public ShipperService(IRepository<Shipper> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ShipperDto>> GetAll()
        {
            var shippers = await this.repository.GetAll();
            return this.mapper.Map<IEnumerable<ShipperDto>>(shippers);
        }

        public async Task<ShipperDto> GetById(int id)
        {
            var shipper = await this.repository.GetById(id);
            return this.mapper.Map<ShipperDto>(shipper);
        }

        public async Task Add(ShipperDto shipperDTO)
        {
            var shipper = this.mapper.Map<Shipper>(shipperDTO);
            await this.repository.Add(shipper);
        }

        public async Task Update(ShipperDto shipperDTO)
        {
            var shipper = this.mapper.Map<Shipper>(shipperDTO);
            await this.repository.Update(shipper);
        }

        public async Task Delete(int id)
        {
            await this.repository.Delete(id);
        }
    }
}
