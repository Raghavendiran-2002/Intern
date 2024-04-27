using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
        Task<Product> GetProductById(int productId);
        Task<Product> DeleteProduct(int productId);
        Task<List<Product>> GetAllProduct();
        Task< Product> UpdateProduct(int productId, string productName,double price, int quantity);
    }
}
