namespace DataAccess.Repositories.Imp
{
    using DataAccess.Data;
    using DataAccess.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ShipperRepository : IRepository<Shipper>
    {
        private readonly StoreContext context;

        public ShipperRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Shipper>> GetAll()
        {
            return await this.context.Shippers.ToListAsync();
        }

        public async Task<Shipper> GetById(int id)
        {
            return await this.context.Shippers.FindAsync(id);
        }

        public async Task Add(Shipper shipper)
        {
            await this.context.Shippers.AddAsync(shipper);
            await this.context.SaveChangesAsync();
        }

        public async Task Update(Shipper shipper)
        {
            this.context.Shippers.Update(shipper);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var shipper = await this.context.Shippers.FindAsync(id);
            if (shipper != null)
            {
                this.context.Shippers.Remove(shipper);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
