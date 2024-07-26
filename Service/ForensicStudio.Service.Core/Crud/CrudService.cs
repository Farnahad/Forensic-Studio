using ForensicStudio.DataAccess.Model.Core;
using ForensicStudio.Service.Core.Container;
using ForensicStudio.Service.Core.Repository;

namespace ForensicStudio.Service.Core.Crud;

public class CrudService<TDbModel> : ICrudService<TDbModel> where TDbModel : class, IDbModel
{
    private readonly IRepositoryService<TDbModel> _repositoryService;

    public CrudService(IContainerService containerService)
    {
        _repositoryService = containerService.Resolve<IRepositoryService<TDbModel>>();
    }

    public virtual async Task<IEnumerable<TDbModel>> GetAllAsync()
    {
        return await _repositoryService.GetAllAsync();
    }

    public virtual async Task<TDbModel> GetByIdAsync(int id)
    {
        return await _repositoryService.GetByIdAsync(id);
    }

    public IQueryable<T> GetQueryable<T>() where T : class, IDbModel
    {
        return  _repositoryService.GetQueryable<T>();
    }

    public void Add(TDbModel dbModel)
    {
        _repositoryService.Add(dbModel);
    }

    public void Remove(TDbModel dbModel)
    {
        _repositoryService.Remove(dbModel);
    }

    public async Task SaveAsync()
    {
        await _repositoryService.SaveAsync();
    }

    public Task<bool> CanRemove(TDbModel dbModel)
    {
        return _repositoryService.CanRemove(dbModel);
    }

    public bool HasChanges()
    {
        return _repositoryService.HasChanges();
    }

    public void Dispose()
    {
        _repositoryService?.Dispose();
    }
}