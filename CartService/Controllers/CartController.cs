using CartApp.DTOs.Outgoing;
using CartApp.Models;
using CartApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var cart = await _cartService.Populate(id);

                return Ok(new ApiResponse<ShoppingCart> { Success = true, Message = "retrieved succefully", Data = cart });
            }
            catch (Exception ex)
            {
                var problem = ex.InnerException?.ToString() ?? ex.Message.ToString();
                return NotFound(problem);
            }
        }

        [HttpPost("NewCart/{productId}")]
        public async Task<IActionResult> AddToNewCart(Guid productId)
        {
            try
            {
                var result = await _cartService.AddProductToNewCart(productId);
                if (result is not null)
                {
                    var cart = await _cartService.Populate(result.Id);
                    return Ok(new ApiResponse<ShoppingCart> { Success = true, Message = "Added", Data = cart });
                }
                else
                {
                    throw new Exception("could not process request");
                }
            }
            catch (Exception ex)
            {
                var problem = ex.InnerException?.ToString() ?? ex.Message.ToString();
                return NotFound(problem);
            }
        }

        [HttpPost("ExistingCart")]
        public async Task<IActionResult> AddToExistingCart(Guid cartId, Guid productId)
        {
            try
            {

                var result = await _cartService.AddProductToExistingCart(cartId, productId);
                if (result)
                {
                    return Ok(new ApiResponse<ShoppingCart> { Success = true, Message = "Added" });

                }
                else
                {
                    throw new Exception("could not process request");
                }
            }
            catch (Exception ex)
            {
                var problem = ex.InnerException?.ToString() ?? ex.Message.ToString();
                return NotFound(problem);
            }
        }
    }
}
