using Grocery.Repo.DTOs;
using Grocery.Repo.Model;
using Grocery.Repo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Repo.Repositories
{
    public class WishListRepository : IWishListRepository
    {
        private readonly GroceryDBContext _context;
        public WishListRepository(GroceryDBContext context)
        {
            _context = context;
        }
        public IEnumerable<WishList>? GetWishLists()
        {
            var wishLists = _context.WishList.ToList();
            if (wishLists != null)
            {
                return wishLists;
            }
            return null;
        }
        public int AddWishList(WishList wishList)
        {
            _context.WishList.Add(wishList);
            try
            {
                _context.SaveChanges();
                return wishList.Id;
            }
            catch(Exception e)
            {
                return 0;
            }
        }
        public WishList? GetWishListById(int id)
        {
            var wishList = _context.WishList.FirstOrDefault(w => w.Id == id);

            if (wishList != null)
            {
                return wishList;
            }
            return null;
        }
      public int AddWishListItem(WishListItem wishListItem)
    {
            try
            {
                _context.WishListItems.Add(wishListItem);
                _context.SaveChanges();
                return wishListItem.Id; // Assuming your WishListItem has an Id property\
            }
            catch(Exception ex)
            {
                return 0;
            }
    }

        public int DeleteWishList(int id)
        {
            var wishList = _context.WishList.Find(id);
            if (wishList != null)
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var wishListItems = _context.WishListItems.Where(w => w.WishListId == id).ToList();
                        if (wishListItems != null)
                        {
                            _context.WishListItems.RemoveRange(wishListItems);
                            _context.SaveChanges();
                        }
                        var deletedId = _context.WishList.Remove(wishList).Entity.Id;
                        _context.SaveChanges();
                        dbContextTransaction.Commit();
                        return deletedId;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        dbContextTransaction.Rollback();
                        return 0;
                    }
                }
            }
            return 0;
        }
        public int DeleteWishListItem(int wishListId, int productId)
        {
            var wishListItem = _context.WishListItems
                .FirstOrDefault(item => item.WishListId == wishListId && item.ProductId == productId);

            if (wishListItem != null)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == productId);

                if (product != null)
                {
                    var wishList = GetWishListById(wishListId);

                    if (wishList != null)
                    {
                        using (var dbContextTransaction = _context.Database.BeginTransaction())
                        {
                            try
                            {
                             //   wishList.TotalAmount -= (product.Price * wishListItem.Quantity);
                                _context.SaveChanges();

                                var deletedId = wishListItem.WishListId;

                                _context.WishListItems.Remove(wishListItem);
                                _context.SaveChanges();

                                dbContextTransaction.Commit();
                                return deletedId;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                dbContextTransaction.Rollback();
                                return 0;
                            }
                        }
                    }
                    return 0;
                }
                return 0;
            }
            return 0;
        }

        public List<Item> GetWishListItemsByCustomerId(int userId)
        {
            //var query = _context.WishList
            //.Where(w => w.CustomerId == userId)
            //.Where(w => w.WishListDetails!.Any())
            //.SelectMany(w => w.WishListDetails!)
            //.Include(p => p.ProductDetails)
            //.Select(p => new Item
            //{
            //    Name = p.ProductDetails!.Name,
            //    Price = p.ProductDetails.Price,
            //    Brand = p.ProductDetails.Brand,
            //    Category = p.ProductDetails.Category,
            //    Unit = p.ProductDetails.Unit,
            //    Description = p.ProductDetails.Description
            //});
            //return query.ToList();
            return null;
        }
        public IEnumerable<WishListItem> GetWishListItemsByWishListId(int wishListId)
        {
            var wishListItems = _context.WishListItems.Where(w => w.WishListId == wishListId).ToList();
            if (wishListItems != null)
            {
                return wishListItems;
            }
            return Enumerable.Empty<WishListItem>();
        }
        public Tuple<List<WishList>, List<WishListItem>> GetWishListDetails(int wishListId)
        {
            var wishList = _context.WishList
               .Where(w => w.Id == wishListId)
               .ToList();

            var WishListItem = _context.WishListItems
                .Where(wi => wi.WishListId == wishListId)
                .ToList();
            return Tuple.Create(wishList, WishListItem);
        }
        public int UpdateWishList(int id, WishList wishList)
        {
            try
            {
                var updatedWishList = _context.WishList.Update(wishList).Entity.Id;
                _context.SaveChanges();
                return updatedWishList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }

        }
    }
}