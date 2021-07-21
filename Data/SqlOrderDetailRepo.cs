using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Smile.Models;

namespace Smile.Data
{
    public class SqlOrderDetailRepo : IOrderDetailRepo
    {
        private readonly SmileContext _context;

        public SqlOrderDetailRepo(SmileContext context)
        {
            _context = context;
        }

        public void CreateOrderDetail(OrderDetail ordDet)
        {
            if(ordDet == null)
            {
                throw new ArgumentNullException(nameof(ordDet));
            }
            _context.OrderDetails.Add(ordDet);
        }

        public void DeleteOrderDetail(OrderDetail ordDet)
        {
            if(ordDet == null)
            {
                throw new ArgumentNullException(nameof(ordDet));
            }
            _context.OrderDetails.Remove(ordDet);
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetails()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailById(int oid)
        {
            return await _context.OrderDetails.FirstOrDefaultAsync(ordDet => ordDet.OrderId == oid);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void UpdateOrderDetail(OrderDetail ordDet)
        {
            //no code needed here
        }
    }
}