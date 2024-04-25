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
        Product AddProduct(Product product);
        Product GetProductById(int productId);
        Product DeleteProduct(int productId);
        List<Product> GetAllProduct();
        Product UpdateProduct(int productId, string productName,double price, int quantity);
    }
}
