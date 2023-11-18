using Grocery.Business.Services.Interface;
using Grocery.Repo.DTOs;
using Grocery.Repo.Model;
using Grocery.Repo.Repositories;
using Grocery.Repo.Repositories.Interface;

namespace Grocery.Business.Services
{
    public class WishListService : IWishListService
    {
        private readonly IWishListRepository _wishListRepo;
        public WishListService(IWishListRepository wishListRepo)
        {
            _wishListRepo = wishListRepo;
        }
        public IEnumerable<WishList>? GetWishLists()
        {
            return _wishListRepo.GetWishLists();
        }
        public WishList? GetWishListById(int id)
        {
            return _wishListRepo.GetWishListById(id);
        }
        public int AddWishList(WishList wishList)
        {
            return _wishListRepo.AddWishList(wishList);
        }
        public int AddWishListItem(WishListItem wishListItem)
        {
            // Validate wishListItem if necessary
            return _wishListRepo.AddWishListItem(wishListItem);
        }
        public int DeleteWishList(int id)
        {
            return _wishListRepo.DeleteWishList(id);
        }
        public int DeleteWishListItem(int wishListId, int productId)
        {
            return _wishListRepo.DeleteWishListItem(wishListId, productId);
        }

        public List<Item> GetWishListItemsByCustomerId(int userId)
        {
            return _wishListRepo.GetWishListItemsByCustomerId(userId);
        }
        public IEnumerable<WishListItem> GetWishListItemsByWishListId(int wishListId)
        {
            return _wishListRepo.GetWishListItemsByWishListId(wishListId);
        }
        public Tuple<List<WishList>, List<WishListItem>> GetWishListDetails(int wishListId)
        {
            return _wishListRepo.GetWishListDetails(wishListId);
        }
        public int UpdateWishList(int id, WishList wishList)
        {
            return _wishListRepo.UpdateWishList(id, wishList);
        }
    }
}