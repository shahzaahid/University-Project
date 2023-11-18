using Grocery.Repo.DTOs;
using Grocery.Repo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Business.Services.Interface
{
    public interface ICartService
    {
        IEnumerable<Cart>? GetCarts();
        int AddCart(Cart cart);
        Cart? GetCartById(int id);
        //  int AddCartItem(CartItem cartitem);
        int AddCartItem(CartItem cartItem);
        int DeleteCart(int id);
        int DeleteCartItem(int id);
        List<Item> GetCartItemsByCustomerId(int userId);
        IEnumerable<CartItem> GetCartItemsByCartId(int cartId);
        Tuple<List<Cart>, List<CartItem>> GetCartDetails(int cartId);
        // int UpdateCart(int id, Cart cart);
        int UpdateCartItem(int cartId, int productId, CartItem updatedCartItem);
        public int RemoveCartItem(int cartId);
    }
}
