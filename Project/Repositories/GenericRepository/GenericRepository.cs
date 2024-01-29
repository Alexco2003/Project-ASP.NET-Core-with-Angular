using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models.Base;

namespace Project.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ProjectContext _ProjectContext;

        protected readonly DbSet<TEntity> _table;

        public GenericRepository(ProjectContext ProjectContext)
        {
            _ProjectContext = ProjectContext;
            _table = ProjectContext.Set<TEntity>();
        }

        // Get all

        public List<TEntity> GetAll()
        {
            return _table.AsNoTracking().ToList();
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }
        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _table.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        // Create

        public void Create(TEntity entity)
        {
            _table.Add(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        // Update
        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
        }

        // Delete
        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }
        public bool DeleteById(Guid id)
        {
            var entity = _table.Find(id);
            if (entity == null) return false;
            _table.Remove(entity);
            return true;
        }

        // Find
        public TEntity FindById(Guid id)
        {
            return _table.Find(id);
        }

        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            return await _table.FindAsync(id);
        }

        // Save
        public bool Save()
        {
            return _ProjectContext.SaveChanges() > 0;
        }
        public async Task<bool> SaveAsync()
        {
            return await _ProjectContext.SaveChangesAsync() > 0;
        }
    }
}
