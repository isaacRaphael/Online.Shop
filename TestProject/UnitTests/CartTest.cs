using CartApp.DTOs.Incoming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.UnitTests
{
    public class CartTest : UnitTestBase
    {
        [Fact]
        public async Task GetById_Should_Return_Cart()
        {
            //Arrange


            //Act            
            var result = await _cartService.GetShoppingCart(cart.Id);

            //Assert
            Assert.Equal(expected: cart.Id.ToString(), actual: result.Id.ToString());
            Assert.True(result.GetType() == cart.GetType());
        }

        [Fact]
        public async Task AddToExistingCart()
        {
            //Arrange

            //Act            
            var result = await _cartService.AddProductToExistingCart(cart.Id, product.Id);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task AddToCart()
        {
            //Arrange

            //Act            
            await _cartService.AddProductToNewCart(product.Id);

            //Assert
            Assert.True(carts.Any());
            Assert.True(carts.Count > 0);
        }
    }
}
