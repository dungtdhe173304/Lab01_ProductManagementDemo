using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        private static List<Product> listProducts = new List<Product>();

        static ProductDAO()
        {
            // Initializing the list with some products for demonstration
            Product chai = new Product(1, "Chai", 3, 12, 18);
            Product chang = new Product(2, "Chang", 1, 23, 19);
            Product aniseed = new Product(3, "Aniseed Syrup", 2, 23, 10);
            listProducts = new List<Product> { chai, chang, aniseed };
        }

        public static List<Product> GetProduct()
        {
            return listProducts;
        }

        public static void SaveProduct(Product p)
        {
            listProducts.Add(p);
        }

        public static void UpdateProduct(Product product)
        {
            var existingProduct = listProducts.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.UnitsInStock = product.UnitsInStock;
                existingProduct.CategoryId = product.CategoryId;
            }
        }

        public static void DeleteProduct(Product product)
        {
            var existingProduct = listProducts.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                listProducts.Remove(existingProduct);
            }
        }

        public static Product GetProductById(int id)
        {
            return listProducts.FirstOrDefault(p => p.ProductId == id);
        }
    }


}
