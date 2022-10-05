namespace CartApp.Repositories.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> Add(T entity);
        Task<T> GetById(Guid id);
        Task<T> Update(T entity);
        Task<T> GetandPopulate(Guid id, string includes);

    }
}
