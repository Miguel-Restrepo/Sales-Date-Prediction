namespace DataAccess.Repositories.Imp
{
    using DataAccess.Data;
    using DataAccess.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductRepository : IRepository<Product>
    {
        private readonly StoreContext context;

        public ProductRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await this.context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await this.context.Products.FindAsync(id);
        }

        public async Task Add(Product product)
        {
            await this.context.Products.AddAsync(product);
            await this.context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            this.context.Products.Update(product);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await this.context.Products.FindAsync(id);
            if (product != null)
            {
                this.context.Products.Remove(product);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
