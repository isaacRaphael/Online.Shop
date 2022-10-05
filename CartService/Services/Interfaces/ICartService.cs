using CartApp.DTOs.Incoming;
using CartApp.Models;

namespace CartApp.Services.Interfaces
{
    public interface ICartService
    {
        Task<bool> AddProductToExistingCart(Guid cartId, Guid productDto);
        Task<ShoppingCart> AddProductToNewCart(Guid productId);
        Task<ShoppingCart> GetShoppingCart(Guid Id);
        Task<ShoppingCart> Populate(Guid id);

    }
}
