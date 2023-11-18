using Grocery.Repo.Model;
using Microsoft.AspNetCore.Mvc;

namespace Grocery.Business.Services.Interface
{
    public interface IOrderService
    {
        List<Order>? GetOrders();
        Order? GetOrderById(int id);
        public int AddOrder(Order order);
    }
}
