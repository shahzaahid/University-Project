using Grocery.Repo.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Grocery.Repo.Repositories.Interface
{
    public interface IProductRepository
    {
        List<Product>? GetProducts();
        Product? GetProductById(int id);
        int AddProduct(Product product);
        int DeleteProduct(int id);
        int UpdateProduct(int id, Product updatedProduct);
        byte[] GetImage(int productId);
    }
}
