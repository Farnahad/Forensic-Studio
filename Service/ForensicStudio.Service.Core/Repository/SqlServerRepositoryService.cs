using ForensicStudio.DataAccess.Data;
using ForensicStudio.DataAccess.Model.Core;
using Microsoft.EntityFrameworkCore;

namespace ForensicStudio.Service.Core.Repository;

public class SqlServerRepositoryService<TEntity> : IRepositoryService<TEntity>
    where TEntity : class, IDbModel
{
    private readonly ForensicStudioSqlServerDbContext _forensicStudioSqlServerDbContext;

    // ReSharper disable once MemberCanBeProtected.Global
    public SqlServerRepositoryService(ForensicStudioSqlServerDbContext forensicStudioSqlServerDbContext)
    {
        _forensicStudioSqlServerDbContext = forensicStudioSqlServerDbContext;
        _forensicStudioSqlServerDbContext.Database.EnsureCreated();
        _forensicStudioSqlServerDbContext.Database.Migrate();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _forensicStudioSqlServerDbContext.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity> GetByIdAsync(int id)
    {
        return await _forensicStudioSqlServerDbContext.Set<TEntity>().FindAsync(id);
    }

    public IQueryable<T> GetQueryable<T>() where T : class, IDbModel
    {
        return _forensicStudioSqlServerDbContext.Set<T>().AsQueryable();
    }

    public void Add(TEntity model)
    {
        _forensicStudioSqlServerDbContext.Set<TEntity>().Add(model);
    }

    public void Remove(TEntity model)
    {
        _forensicStudioSqlServerDbContext.Set<TEntity>().Remove(model);
    }

    public async Task SaveAsync()
    {
        await _forensicStudioSqlServerDbContext.SaveChangesAsync();
    }

    public Task<bool> CanRemove(TEntity dbModel)
    {
        var entityType = _forensicStudioSqlServerDbContext.Model.FindEntityType(typeof(TEntity));
        var primaryKey = entityType.FindPrimaryKey();
        var primaryKeyProperties = primaryKey.Properties;
        var primaryKeyValues = primaryKeyProperties.Select(p => p.PropertyInfo.GetValue(entityType)).ToArray();
        // Iterate through all entities and their properties
        foreach (var entity in _forensicStudioSqlServerDbContext.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                var foreignKey = entity.FindForeignKeys(property)
                    .FirstOrDefault(fk => fk.PrincipalEntityType.ClrType == typeof(TEntity));

                if (foreignKey != null)
                {
                    //var dbSet = _forensicStudioSqlServerDbContext.Set<TEntity>(entity.ClrType.ToString());
                    //var referencedEntities = await dbSet.AsQueryable().AsNoTracking()
                    //    .Where(e => EF.Property<object>(e, property.Name)
                    //        .Equals(primaryKeyValues[0])).CountAsync();

                    //if (referencedEntities > 0)
                    //{
                    //    return Task.FromResult(false);
                    //}
                }
            }
        }

        return Task.FromResult(true);



        //using var transaction = _forensicStudioSqlServerDbContext.Database.BeginTransaction();

        //try
        //{
        //    _forensicStudioSqlServerDbContext.Set<TEntity>().Remove(dbModel);
        //    var entityEntry = _forensicStudioSqlServerDbContext.ChangeTracker.Entries<TEntity>()
        //             .First(item => item.Entity.Id == dbModel.Id);

        //    transaction.Rollback();
        //    return true;
        //}
        //catch (Exception)
        //{
        //    // TODO: Handle failure
        //}



        //return Task.FromResult(true);
    }

    public bool HasChanges()
    {
        return _forensicStudioSqlServerDbContext.ChangeTracker.HasChanges();
    }

    public void Dispose()
    {
        _forensicStudioSqlServerDbContext?.Dispose();
    }
}