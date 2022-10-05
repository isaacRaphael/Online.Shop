using AutoMapper;
using CartApp.DTOs.Incoming;
using CartApp.Models;
using CartApp.Repositories.Interfaces;
using CartApp.Services.Interfaces;

namespace CartApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Product> AddProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var result = await _unitOfWork.ProductRepository.Add(product);
            return result;
        }

        public async Task<Product> GetProduct(Guid Id)
        {
            return await _unitOfWork.ProductRepository.GetById(Id);
        }
    }
}
