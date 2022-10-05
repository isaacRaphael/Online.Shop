using CartApp.DTOs.Incoming;
using CartApp.DTOs.Outgoing;
using CartApp.Models;
using CartApp.Repositories.Interfaces;
using CartApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = await _productService.AddProduct(dto);
                return Ok(new ApiResponse<Product> { Success = true, Message = "Created", Data = result });
            }catch(Exception ex)
            {
                var problem = ex.InnerException?.ToString() ?? ex.Message.ToString();
                return BadRequest(problem);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _productService.GetProduct(id);
                return Ok(new ApiResponse<Product> { Success = true, Message = "retrieved", Data = result });
            }
            catch(Exception ex)
            {
                var problem = ex.InnerException?.ToString() ?? ex.Message.ToString();
                return BadRequest(problem);
            }
        }
    }
}
