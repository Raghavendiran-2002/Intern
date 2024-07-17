using ProductManagement.DTOs;

namespace ProductManagement.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
        Task AddProduct(ProductDTO productDTO);
        Task UpdateProduct(int id, ProductDTO productDTO);
        Task DeleteProduct(int id);
    }
}

