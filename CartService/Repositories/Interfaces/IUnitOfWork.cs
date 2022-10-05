namespace CartApp.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository ProductRepository { get; }
        public ICartRepository CartRepository { get; }

        Task<int> CompleteAync();
    }
}
