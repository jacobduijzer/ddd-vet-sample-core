using System.Collections.Generic;
using System.Threading.Tasks;
using ClientPatientManagement.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClientPatientManagement.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly CrudContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository()
        {

        }
        public Repository(CrudContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> List() => await _dbSet.ToListAsync().ConfigureAwait(false);

        public TEntity GetById(int id) => _dbSet.Find(id);

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
            _context.SaveChanges();
        }
    }
}
