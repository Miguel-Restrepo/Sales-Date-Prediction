namespace DataAccess.Repositories.Imp
{
    using DataAccess.Data;
    using DataAccess.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class OrderRepository : IRepository<Order>
    {
        private readonly StoreContext context;

        public OrderRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await this.context.Orders.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await this.context.Orders.FindAsync(id);
        }

        public async Task Add(Order order)
        {
            await this.context.Orders.AddAsync(order);
            await this.context.SaveChangesAsync();
        }

        public async Task Update(Order order)
        {
            this.context.Orders.Update(order);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var order = await this.context.Orders.FindAsync(id);
            if (order != null)
            {
                this.context.Orders.Remove(order);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
