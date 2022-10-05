using CartApp.DTOs.Incoming;
using CartApp.Models;

namespace CartApp.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product>   AddProduct(ProductDto productDto);
        Task<Product> GetProduct(Guid Id);
    }
}
