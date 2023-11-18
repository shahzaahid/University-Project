using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.Entity.Infrastructure;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Repo.Model
{
    public class GroceryDBContext: DbContext
    {
        public GroceryDBContext(DbContextOptions<GroceryDBContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UsersAddress { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Promo> Promo { get; set; }
        public DbSet<WishList> WishList { get; set; }
        public DbSet<WishListItem> WishListItems { get; set; }

    }
}
