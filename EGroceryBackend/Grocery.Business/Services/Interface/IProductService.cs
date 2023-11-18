using Grocery.Repo.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Grocery.Business.Services.Interface
{
    public interface IProductService
    {
        List<Product>? GetProducts();
        Product? GetProductById(int id);
        int AddProduct(Product product);
        int DeleteProduct(int id);
        int UpdateProduct(int id,Product updatedProduct);
        byte[] GetProductImage(int productId);
    }
}
