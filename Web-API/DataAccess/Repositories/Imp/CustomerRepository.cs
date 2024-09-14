namespace DataAccess.Repositories.Imp
{
    using DataAccess.Data;
    using DataAccess.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CustomerRepository : IRepository<Customer>
    {
        private readonly StoreContext context;

        public CustomerRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await this.context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await this.context.Customers.FindAsync(id);
        }

        public async Task Add(Customer customer)
        {
            await this.context.Customers.AddAsync(customer);
            await this.context.SaveChangesAsync();
        }

        public async Task Update(Customer customer)
        {
            this.context.Customers.Update(customer);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var customer = await this.context.Customers.FindAsync(id);
            if (customer != null)
            {
                this.context.Customers.Remove(customer);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
