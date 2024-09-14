namespace DataAccess.Repositories.Imp
{
    using DataAccess.Data;
    using DataAccess.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly StoreContext context;

        public EmployeeRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await this.context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await this.context.Employees.FindAsync(id);
        }

        public async Task Add(Employee employee)
        {
            await this.context.Employees.AddAsync(employee);
            await this.context.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            this.context.Employees.Update(employee);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var employee = await this.context.Employees.FindAsync(id);
            if (employee != null)
            {
                this.context.Employees.Remove(employee);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
