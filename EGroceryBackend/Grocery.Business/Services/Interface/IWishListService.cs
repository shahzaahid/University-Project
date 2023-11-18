using Grocery.Repo.DTOs;
using Grocery.Repo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Business.Services.Interface
{
    public interface IWishListService
    {
        IEnumerable<WishList>? GetWishLists();
        int AddWishList(WishList wishList);
        WishList? GetWishListById(int id);
        int AddWishListItem(WishListItem wishListItem);
        int DeleteWishList(int id);
        // int DeleteWishListItem(int id);
        int DeleteWishListItem(int wishListId, int productId);
        List<Item> GetWishListItemsByCustomerId(int userId);
        IEnumerable<WishListItem> GetWishListItemsByWishListId(int wishListId);
        Tuple<List<WishList>, List<WishListItem>> GetWishListDetails(int wishListId);
        int UpdateWishList(int id, WishList wishList);
    }
}