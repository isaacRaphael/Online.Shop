using CartApp.Repositories.Implementations;
using CartApp.Repositories.Interfaces;
using CartApp.Services;
using CartApp.Services.Interfaces;

namespace CartApp.Extensions
{
    public static class AddRequired
    {
        public static WebApplicationBuilder AddRequiredServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICartService, CartService>();

            return builder;
        }
    }
}
