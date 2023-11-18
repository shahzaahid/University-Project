using Grocery.Business.Services.Interface;
using Grocery.Repo.DTOs;
using Grocery.Repo.Model;
using Grocery.Repo.Repositories;
using Grocery.Repo.Repositories.Interface;

namespace Grocery.Business.Services
{
    public class CartService: ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public IEnumerable<Cart>? GetCarts()
        {
            return _cartRepository.GetCarts();
        }
        public Cart? GetCartById(int id)
        {
            return _cartRepository.GetCartById(id);
        }
        public int AddCart(Cart cart)
        {
            return _cartRepository.AddCart(cart);
        }
        public int AddCartItem(CartItem cartItem)
        {
            // Validate cartItem if necessary
            return _cartRepository.AddCartItem(cartItem);
        }
        public int DeleteCart(int id)
        {
            return _cartRepository.DeleteCart(id);
        }
        public int DeleteCartItem(int id)
        {
            return _cartRepository.DeleteCartItem(id);
        }
        public int RemoveCartItem(int cartId)
        {
            return _cartRepository.RemoveCartItem(cartId);
        }

        public List<Item> GetCartItemsByCustomerId(int userId)
        {
            return _cartRepository.GetCartItemsByCustomerId(userId);
        }
        public IEnumerable<CartItem> GetCartItemsByCartId(int cartId)
        {
            return _cartRepository.GetCartItemsByCartId(cartId);
        }
        public Tuple<List<Cart>, List<CartItem>> GetCartDetails(int cartId)
        {
            return _cartRepository.GetCartDetails(cartId);
        }
        public int UpdateCartItem(int cartId, int productId, CartItem updatedCartItem)
        {
            return _cartRepository.UpdateCart(cartId,productId, updatedCartItem);
        }
    }
}
