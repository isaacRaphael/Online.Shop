using CartApp.Data;
using CartApp.Models;
using CartApp.Repositories.Interfaces;

namespace CartApp.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
