using Grocery.Repo.DTOs;
using Grocery.Repo.Model;
using Grocery.Repo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Repo.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly GroceryDBContext _context;
        public CartRepository(GroceryDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Cart>? GetCarts()
        {
            var carts = _context.Cart.ToList();
            if (carts != null)
            {
                return carts;
            }
            return null;
        }
        public int AddCart(Cart cart)
        {
            _context.Cart.Add(cart);
            try
            {
                _context.SaveChanges();
                return cart.Id;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public Cart? GetCartById(int id)
        {
            var cart = _context.Cart.FirstOrDefault(c => c.Id == id);

            if (cart != null)
            {
                return cart;
            }
            return null;
        }
        public int AddCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
            return cartItem.Id; // Assuming your CartItem has an Id property
        }
        public int DeleteCart(int id)
        {
            var cart = _context.Cart.Find(id);
            if (cart != null)
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var cartItems = _context.CartItems.Where(c => c.CartId == id).ToList();
                        if (cartItems != null)
                        {
                            _context.CartItems.RemoveRange(cartItems);
                            _context.SaveChanges();
                        }
                        var deletedId = _context.Cart.Remove(cart).Entity.Id;
                        _context.SaveChanges();
                        dbContextTransaction.Commit();
                        return deletedId;
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        return 0;
                    }
                }
            }
            return 0;
        }
        //Delete Cart Item
        //Delete Cart Item
        //public int DeleteCartItem(int productId)
        //{
        //    var cartItem = _context.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
        //    if (cartItem != null)
        //    {
        //        var product = _context.Products.FirstOrDefault(p => p.Id == cartItem.ProductId);
        //        if (product != null)
        //        {
        //            var cart = GetCartById(cartItem.CartId);
        //            if (cart != null)
        //            {
        //                using (var dbContextTransaction = _context.Database.BeginTransaction())
        //                {
        //                    try
        //                    {
        //                        //cart.TotalAmount -= (product.Price * cartItem.Quantity);
        //                        _context.SaveChanges();
        //                        // Delete cart item
        //                        var deletedId = _context.CartItems.Remove(cartItem).Entity.Id;
        //                        _context.SaveChanges();
        //                        dbContextTransaction.Commit();
        //                        return deletedId;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Console.WriteLine(ex);
        //                        dbContextTransaction.Rollback();
        //                        return 0;
        //                    }
        //                }
        //            }
        //            return 0;
        //        }
        //        return 0;
        //    }
        //    return 0;
        //}
        public int DeleteCartItem(int productId)
        {
            var cartItem = _context.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem != null)
            {

                try
                {
                    var deletedId = _context.CartItems.Remove(cartItem).Entity.Id;
                    _context.SaveChanges();

                    return deletedId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                    return 0;
                }


            }
            return 0;
        }
    

        public int RemoveCartItem(int cartId)
{
            var cartItems = _context.CartItems.Where(ci => ci.CartId == cartId).ToList();

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var cartItem in cartItems)
                    {
                        _context.CartItems.Remove(cartItem);
                    }

                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return cartId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    dbContextTransaction.Rollback();
                    return 0;
                }
            }

        }


        public List<Item> GetCartItemsByCustomerId(int userid)
        {
            //var query = _context.Cart
            //.Where(c => c.CustomerId == userid)
            //.Where(c => c.CartDetails.Any())
            //.SelectMany(c => c.CartDetails)
            //.Include(ci => ci.ProductDetails)
            //.Select(ci => new Item
            //{
            //    Name = ci.ProductDetails.Name,
            //    Price = ci.ProductDetails.Price,
            //    Brand = ci.ProductDetails.Brand,
            //    Category = ci.ProductDetails.Category,
            //    Unit = ci.ProductDetails.Unit,
            //    Description = ci.ProductDetails.Description,
            //});
            //return query.ToList();
            return null;
        }
        public IEnumerable<CartItem> GetCartItemsByCartId(int cartId)
        {
            var cartItems = _context.CartItems.Where(c => c.CartId == cartId).ToList();
            if(cartItems != null)
            {
                return cartItems;
            }
            return Enumerable.Empty<CartItem>();
        }
        public Tuple<List<Cart>, List<CartItem>> GetCartDetails(int cartId)
        {
            var cart = _context.Cart
               .Where(c => c.Id == cartId)
               .ToList();

            var cartItems = _context.CartItems
                .Where(ci => ci.CartId == cartId)
                .ToList();
            return Tuple.Create(cart, cartItems);
        }
        public int UpdateCart(int cartId, int productId, CartItem updatedCartItem)
        {
            var existingCartItem = _context.CartItems.FirstOrDefault(ci => ci.CartId == cartId && ci.ProductId == productId);


            if (existingCartItem != null)
            {
                existingCartItem.Quantity = updatedCartItem.Quantity; // Update other properties as needed
                existingCartItem.TotalAmount = updatedCartItem.TotalAmount;

                _context.SaveChanges();
                return existingCartItem.Id;
            }

            return 0; // Return some appropriate value to indicate failure
        }

    }
}
