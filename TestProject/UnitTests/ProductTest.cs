using CartApp.DTOs.Incoming;
using Xunit;

namespace TestProject.UnitTests
{
    public class ProductTest : UnitTestBase
    {

        [Fact]
        public async Task GetById_Should_Return_Product()
        {
            //Arrange
            

            //Act            
            var result = await  _productService.GetProduct(product.Id);

            //Assert
            Assert.Equal(expected: product.Id.ToString(), actual: result.Id.ToString());
            Assert.True(result.GetType() == product.GetType());

        }

        [Fact]
        public async Task Add_Should_Add_And_Return_Product()
        {
            //Arrange
            var dto = new ProductDto() { Name = "Test product" };

            //Act            
            await _productService.AddProduct(dto);

            //Assert
            Assert.True(products.Any());
            Assert.True(products.Count > 0);
        }
    }
}
