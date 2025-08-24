using ECommerceApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 101, Name = "Laptop", Category = "Electronics", Price = 1200.00m },
            new Product { Id = 102, Name = "Smartphone", Category = "Electronics", Price = 800.00m },
            new Product { Id = 201, Name = "T-Shirt", Category = "Apparel", Price = 25.00m },
            new Product { Id = 202, Name = "Jeans", Category = "Apparel", Price = 60.00m }
        };

        public Product GetProduct(string category, int id)
        {
            return _products.FirstOrDefault(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase) && p.Id == id);
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        // 👇 THIS METHOD MUST RETURN IEnumerable<string>
        public IEnumerable<string> GetCategories()
        {
            return new List<string> { "Electronics", "Apparel" };
        }
    }
}