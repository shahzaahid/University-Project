using Grocery.Repo.Model;
using Grocery.Repo.Repositories.Interface;
using System.Linq.Expressions;

namespace Grocery.Repo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly GroceryDBContext _context;
        public ProductRepository(GroceryDBContext context)
        {
            _context = context;
            
        }
        /*public List<Product> GetProducts()
        {
            //return "SELECT * FROM PRODUCTS;";
            return _context.Products.ToList();
        }*/

        public List<Product>? GetProducts()
        {
            var products = _context.Products.ToList();

            if (products.Count == 0)
            {
                // Handle the case when no products are found
                // You might throw an exception, log an error, or return an empty list
                // For example, you can return an empty list to indicate that no products were found
                return new List<Product>();
            }

            // If products are found, return the list
            return products;
        }

        public Product? GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                return product;
            }
            return null;
        }

        public int AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.Id;
        }

        public int DeleteProduct(int id)
        {
            //var product = _context.Products.Find(id);
            var product = _context.Products.Where(p => p.Id == id).SingleOrDefault();

            //Product with the given ID not found, return null or throw an exception

            if (product != null)
            {
                try
                {
                    var deletedId = _context.Products.Remove(product).Entity.Id;
                    _context.SaveChanges();
                    return deletedId;
                }
                catch (Exception e)
                {
                    return 0;
                }    
            }
            return -1;
        }

        // In the Repository class
        public int UpdateProduct(int id, Product updatedProduct)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                // Update the properties of the product with the new values
                _context.Entry(product).CurrentValues.SetValues(updatedProduct);

                // Save the changes to the database
                _context.SaveChanges();
                return product.Id;
            }

            return -1; // For example, return a negative value to indicate that the product was not found
        }

        public byte[] GetImage(int productId)
        {
            // Change according to your path
           // var baseDirectory = @"C:\Users\Danish\Desktop\LELALE INTERNSHIP\EGroceryBackend\Grocery.Repo\Images\ProductImages\";
            var baseDirectory = @"..\Grocery.Repo\Images\ProductImages\";
            string[] imageFiles = Directory.GetFiles(baseDirectory, $"{productId}.*");

            if (imageFiles.Length > 0)
            {
                string imageFilePath = imageFiles[0];
                return File.ReadAllBytes(imageFilePath);
            }

            return null;
        }

    }
}

