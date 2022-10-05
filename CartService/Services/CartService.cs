using AutoMapper;
using CartApp.DTOs.Incoming;
using CartApp.Models;
using CartApp.Repositories.Interfaces;
using CartApp.Services.Interfaces;

namespace CartApp.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddProductToExistingCart(Guid cartId, Guid productId)
        {
            var cart = await _unitOfWork.CartRepository.GetById(cartId);
            if (cart is null)
                return false;
            var product = await _unitOfWork.ProductRepository.GetById(productId);
            product.CartId = cartId;
            await _unitOfWork.ProductRepository.Update(product);
            return true;
        }

        public async Task<ShoppingCart> AddProductToNewCart(Guid productId)
        {
            var cart = new ShoppingCart();
            await _unitOfWork.CartRepository.Add(cart);

            var product = await _unitOfWork.ProductRepository.GetById(productId);
            product.CartId = cart.Id;
            await _unitOfWork.ProductRepository.Update(product);
            return cart;
        }

        public Task<ShoppingCart> GetShoppingCart(Guid Id)
        {
            return _unitOfWork.CartRepository.GetById(Id);
        }


        public Task<ShoppingCart> Populate(Guid id)
        {
            return _unitOfWork.CartRepository.GetandPopulate(id, "Products");
        }
    }
}
