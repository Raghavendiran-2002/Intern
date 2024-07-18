using ProductManagement.DTOs;
using ProductManagement.Models;

namespace ProductManagement.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
        Task<Product> AddProduct(ProductDTO productDTO);
        Task<Product> UpdateProduct(int id, ProductDTO productDTO);
        Task DeleteProduct(int id);
    }
}

