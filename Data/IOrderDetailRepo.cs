using System.Collections.Generic;
using System.Threading.Tasks;
using Smile.Models;

namespace Smile.Data
{
    public interface IOrderDetailRepo
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetails();
        Task<OrderDetail> GetOrderDetailById(int oid);
        void CreateOrderDetail(OrderDetail ordDet);
        void UpdateOrderDetail(OrderDetail ordDet);
        void DeleteOrderDetail(OrderDetail ordDet);
        Task<bool> SaveChangesAsync();
    }
}