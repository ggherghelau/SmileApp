using System.Collections.Generic;
using System.Threading.Tasks;
using Smile.Models;

namespace Smile.Data
{
    public interface IOrderRepo
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        void CreateOrder(Order ord);
        void UpdateOrder(Order ord);
        void DeleteOrder(Order ord);
        Task<bool> SaveChangesAsync();
    }
}