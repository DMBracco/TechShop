using System.Linq;
using TechShop.Data.Entities;

namespace TechShop.Data.Repositories
{

    public interface IOrderRepository {

        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
