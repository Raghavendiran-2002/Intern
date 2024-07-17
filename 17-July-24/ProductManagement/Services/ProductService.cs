using ProductManagement.DTOs;
using ProductManagement.Models;
using ProductManagement.Repositories;

namespace ProductManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = await _repository.GetAllProducts();
            return products.Select(p => new ProductDTO
            {
                Name = p.Name,
                Price = p.Price,
                ImgURL = p.ImgURL
            }).ToList();
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await _repository.GetProductById(id);
            if (product == null)
            {
                return null;
            }
            return new ProductDTO
            {
                Name = product.Name,
                Price = product.Price,
                ImgURL = product.ImgURL
            };
        }

        public async Task AddProduct(ProductDTO productDTO)
        {
            var product = new Product
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                ImgURL = productDTO.ImgURL
            };
            await _repository.AddProduct(product);
        }

        public async Task UpdateProduct(int id, ProductDTO productDTO)
        {
            var product = await _repository.GetProductById(id);
            if (product != null)
            {
                product.Name = productDTO.Name;
                product.Price = productDTO.Price;
                product.ImgURL = productDTO.ImgURL;
                await _repository.UpdateProduct(product);
            }
        }

        public async Task DeleteProduct(int id)
        {
            await _repository.DeleteProduct(id);
        }
    }
}
