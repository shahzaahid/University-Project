using Grocery.Business.Helper;
using Grocery.Business.Services.Interface;
using Grocery.Repo.Model;
using Grocery.Repo.Repositories;
using Grocery.Repo.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Grocery.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order>? GetOrders()
        {
            var orders = _orderRepository.GetOrders();
            if (orders != null)
                return orders;
            return null;
        }
        public Order? GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }
        public int AddOrder(Order order)
        {
            return _orderRepository.AddOrder(order);
             
        }
    }
}
