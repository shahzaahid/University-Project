using Grocery.Repo.DTOs;
using Grocery.Repo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Repo.Repositories.Interface
{
    public interface ICartRepository
    {
        IEnumerable<Cart>? GetCarts();
        int AddCart(Cart cart);
        int AddCartItem( CartItem cartitem);
        Cart? GetCartById(int id);
        int DeleteCart(int id);
        int DeleteCartItem(int id);
        List<Item> GetCartItemsByCustomerId(int userId);
        IEnumerable<CartItem> GetCartItemsByCartId(int cartId);
        Tuple<List<Cart>, List<CartItem>> GetCartDetails(int cartId);
        // int UpdateCart(int id, Cart cart);
        int UpdateCart(int cartId, int productId, CartItem updatedCartItem);
        public int RemoveCartItem(int cartId);
    }
}
