using Grocery.Repo.Model;
using Grocery.Repo.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Grocery.Repo.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GroceryDBContext _context;
        public OrderRepository(GroceryDBContext context)
        {
            _context = context;
        }
        public List<Order>? GetOrders()
        {
            try
            {
                // Retrieve orders from the database
                var orders = _context.Orders.ToList();

                // If orders are found, return the list
                return orders;
            }
            catch (Exception ex)
            {
                // Handle exceptions, log the error, and return an empty list or null based on your requirement
                Console.Error.WriteLine($"Error occurred while retrieving orders: {ex.Message}");
                return null; // or return new List<Order>(); based on your error handling strategy
            }
        }

        public Order? GetOrderById(int id)
        {
            var orders = _context.Orders.FirstOrDefault(o => o.CustomerId == id);

            if (orders != null)
            {
                return orders;
            }
            return null;
        }
        public int AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order.Id;
               
        }


    }
}
