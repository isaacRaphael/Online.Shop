using CartApp.Data;
using CartApp.Models;
using CartApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace CartApp.Repositories.Implementations
{
    public class CartRepository : GenericRepository<ShoppingCart>, ICartRepository
    {
        public CartRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
