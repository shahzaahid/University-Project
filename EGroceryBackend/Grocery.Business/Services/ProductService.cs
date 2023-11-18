using Grocery.Business.Helper;
using Grocery.Business.Services.Interface;
using Grocery.Repo.Model;
using Grocery.Repo.Repositories.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Grocery.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository ProductRepository)
        {
                _productRepository = ProductRepository;
        }
        public List<Product>? GetProducts()
        {
            try
            {

                var products = _productRepository.GetProducts();
                if (products != null && products.Count > 0)
                    return products;
                throw new Exception();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Product? GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public int AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public int DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }
        public int UpdateProduct(int id,Product updatedProduct) 
        {
            return _productRepository.UpdateProduct(id,updatedProduct);
        }

        public byte[] GetProductImage(int productId)
        {
            return _productRepository.GetImage(productId);
        }

    }
}
