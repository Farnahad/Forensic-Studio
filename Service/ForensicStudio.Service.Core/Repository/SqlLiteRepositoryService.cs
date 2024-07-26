using ForensicStudio.DataAccess.Data;
using ForensicStudio.DataAccess.Model.Core;
using Microsoft.EntityFrameworkCore;

namespace ForensicStudio.Service.Core.Repository;

public class SqlLiteRepositoryService<TEntity> : IRepositoryService<TEntity>
    where TEntity : class, IDbModel
{
    private readonly ForensicStudioSqliteDbContext _forensicStudioSqliteDbContext;

    // ReSharper disable once MemberCanBeProtected.Global
    public SqlLiteRepositoryService(ForensicStudioSqliteDbContext forensicStudioSqliteDbContext)
    {
        _forensicStudioSqliteDbContext = forensicStudioSqliteDbContext;
        forensicStudioSqliteDbContext.Database.EnsureCreated();
        forensicStudioSqliteDbContext.Database.Migrate();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _forensicStudioSqliteDbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public virtual async Task<TEntity> GetByIdAsync(int id)
    {
        return await _forensicStudioSqliteDbContext.Set<TEntity>().FindAsync(id);
    }

    public IQueryable<T> GetQueryable<T>() where T : class, IDbModel
    {
        return _forensicStudioSqliteDbContext.Set<T>().AsQueryable();
    }

    public void Add(TEntity model)
    {
        _forensicStudioSqliteDbContext.Set<TEntity>().Add(model);
    }

    public void Remove(TEntity model)
    {
        _forensicStudioSqliteDbContext.Set<TEntity>().Remove(model);
    }

    public async Task SaveAsync()
    {
        await _forensicStudioSqliteDbContext.SaveChangesAsync();
    }

    public Task<bool> CanRemove(TEntity dbModel)
    {
        return Task.FromResult(true);
    }

    public bool HasChanges()
    {
        return _forensicStudioSqliteDbContext.ChangeTracker.HasChanges();
    }

    public void Dispose()
    {
        _forensicStudioSqliteDbContext?.Dispose();
    }
}