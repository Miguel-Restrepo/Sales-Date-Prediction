namespace DataAccess.Repositories.Imp
{
    using DataAccess.Data;
    using DataAccess.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;
    using System.Threading.Tasks;

    public class CustomRepository : ICustomRepository
    {
        private readonly StoreContext context;

        public CustomRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int id)
        {
            return await this.context.Orders
                         .Where(o => o.CustId == id)
                         .ToListAsync();
        }

        public async Task<IEnumerable<CustomerOrderPrediction>> GetSalesDatePrediction()
        {
            var query = @"
            WITH OrderIntervals AS (
                SELECT 
                    o.[custid],
                    DATEDIFF(DAY, LAG(o.OrderDate) OVER (PARTITION BY o.[custid] ORDER BY o.[orderdate]), o.[orderdate]) AS DaysBetweenOrders
                FROM 
                    [Sales].[Orders] o
            )
            SELECT 
                c.[companyname],
                MAX(o.[orderdate]) AS LastOrderDate,
                DATEADD(DAY, AVG(oi.[DaysBetweenOrders]), MAX(o.[orderdate])) AS NextPredictedOrder, o.[custid]
            FROM 
                [Sales].[Customers] c
            JOIN 
                [Sales].[Orders] o ON c.[custid] = o.[custid]
            LEFT JOIN 
                OrderIntervals oi ON o.[custid] = oi.[custid]
            GROUP BY 
                c.[companyname], o.[custid]
            HAVING 
                COUNT(o.[orderid]) > 1;";
            var result = await this.context.CustomerOrderPredictions
                                    .FromSqlRaw(query)
                                    .ToListAsync();

            return result;
        }
        
        public async Task CreateOrderAsync(Order order, OrderDetail orderDetails)
        {
            var transaction = await this.context.Database.BeginTransactionAsync();

            try
            {
                this.context.Orders.Add(order);
                await this.context.SaveChangesAsync();

                var orderId = order.OrderId;

                orderDetails.OrderId = orderId;
                this.context.OrderDetails.Add(orderDetails);

                await this.context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
