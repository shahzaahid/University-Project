using Grocery.Repo.Model;
using Microsoft.AspNetCore.Mvc;

namespace Grocery.Repo.Repositories.Interface
{
    public interface IOrderRepository
    {
        List<Order>? GetOrders();
        Order? GetOrderById(int id);
        public int AddOrder(Order order);
    }
}
