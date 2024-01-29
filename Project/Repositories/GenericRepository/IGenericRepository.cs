using Project.Models.Base;

namespace Project.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        // Get all
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        // Create 
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        // Update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        // Delete
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        bool DeleteById(Guid id);

        // Find
        TEntity FindById(Guid id);
        Task<TEntity> FindByIdAsync(Guid id);

        // Save
        bool Save();
        Task<bool> SaveAsync();
    }
}
