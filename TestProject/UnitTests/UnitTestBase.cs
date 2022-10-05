using AutoMapper;
using CartApp.Data;
using CartApp.DTOs.Incoming;
using CartApp.Models;
using CartApp.Repositories.Implementations;
using CartApp.Repositories.Interfaces;
using CartApp.Services;
using CartApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.UnitTests
{
    public class UnitTestBase
    {
        protected readonly IProductService _productService;
        protected readonly ICartService _cartService;

        protected Product product;
        protected ShoppingCart cart;

        protected readonly Mock<IUnitOfWork> _unitOfWork;
        protected List<Product> products = new List<Product>();
        protected List<ShoppingCart> carts = new List<ShoppingCart>();
        protected DbContextOptions<DatabaseContext> _context;

        public UnitTestBase()
        {
            _context = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "ShopDB").Options;
            _unitOfWork = new Mock<IUnitOfWork>();
            var _mapper = new Mock<IMapper>();
            
            product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Apples"
            };

            cart = new ShoppingCart
            {
                Id = Guid.NewGuid()
            };

            var updatedProduct = product;
            updatedProduct.CartId = cart.Id;

            _productService = new ProductService(_unitOfWork.Object, _mapper.Object);
            _unitOfWork.Setup(x => x.ProductRepository.GetById(product.Id)).ReturnsAsync(product);
            _unitOfWork.Setup(x => x.ProductRepository.Update(product)).ReturnsAsync(updatedProduct);
            _unitOfWork.Setup(c => c.ProductRepository.Add(It.IsAny<Product>()))
                .Callback((Product product) =>
                    products.Add(product)
                );

            _cartService = new CartService(_unitOfWork.Object, _mapper.Object);
            _unitOfWork.Setup(x => x.CartRepository.GetById(cart.Id)).ReturnsAsync(cart);
            _unitOfWork.Setup(x => x.CartRepository.Add(It.IsAny<ShoppingCart>()))
                .Callback((ShoppingCart cart) => carts.Add(cart));

        }
    }
}
