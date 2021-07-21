using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Smile.Models;

namespace Smile.Data
{
    public class SqlOrderRepo : IOrderRepo
    {
        private readonly SmileContext _context;

        public SqlOrderRepo(SmileContext context)
        {
            _context = context;
        }

        public void CreateOrder(Order ord)
        {
            if(ord == null)
            {
                throw new ArgumentNullException(nameof(ord));
            }
            _context.Orders.Add(ord);
        }

        public void DeleteOrder(Order ord)
        {
            if(ord == null)
            {
                throw new ArgumentNullException(nameof(ord));
            }
            _context.Orders.Remove(ord);
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(ord => ord.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void UpdateOrder(Order ord)
        {
            //no code needed here
        }
    }
}