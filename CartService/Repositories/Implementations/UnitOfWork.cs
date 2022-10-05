using CartApp.Data;
using CartApp.Repositories.Interfaces;

namespace CartApp.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;

            ProductRepository = new ProductRepository(_context);
            CartRepository = new CartRepository(_context);
        }

        public IProductRepository ProductRepository { get; set; }
        public ICartRepository CartRepository { get; set; }

        public async Task<int> CompleteAync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                    _context.Dispose();
            }
        }
    }
}
