using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class ProductBL : IProductService
    {
        readonly IRepository<int, Product> _productRepo;

        public ProductBL(IRepository<int, Product> productRepo) {
            _productRepo = productRepo;
        }
        public Product AddProduct(Product product)
        {
            Product result = _productRepo.Add(product);
            if (result != null)
            {
                return result;
            }
            throw new UserDefinedException.NoCustomerWithGiveIdException();
        }

        public Product DeleteProduct(int productId)
        {
            Product product = _productRepo.GetByKey(productId);
            if (product != null)
            {
                _productRepo.Delete(productId);
                return product;
            }
            throw new UserDefinedException.NoProductWithGiveIdException();
        }

        public List<Product> GetAllProduct()
        {
            List<Product> res = (List<Product>)_productRepo.GetAll();
            if(res != null) { return res; }
            throw new UserDefinedException.NoProductWithGiveIdException();
        }

        public Product GetProductById(int productId)
        {
            Product product = _productRepo.GetByKey(productId);
            if (product != null)
            {
                return product;
            }
            throw new UserDefinedException.NoCustomerWithGiveIdException();
        }

        public Product UpdateProduct(int productId, string productName, double price, int quantity)
        {
            Product product = _productRepo.GetByKey(productId);
            if(product != null)
            {
                product.Name = productName;
                product.QuantityInHand = quantity;
                product.Price = price;
                var updatedProd = _productRepo.Update(product);
                return updatedProd;
            }
            throw new UserDefinedException.NoProductWithGiveIdException();
        }
    }
}   
