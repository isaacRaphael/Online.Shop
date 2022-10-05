
using Microsoft.EntityFrameworkCore;
using CartApp.Data;
using CartApp.Models.Base;
using CartApp.Repositories.Interfaces;

namespace CartApp.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext _context;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public  async Task<T> GetandPopulate(Guid id, string includes)
        {
            return await _context.Set<T>().Where(x => x.Id == id).Include(includes).FirstAsync();
        }

        public async Task<T> GetById(Guid id)
        {
           return await _context.Set<T>().Where(x => x.Id == id).FirstAsync();

        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
