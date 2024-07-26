using ForensicStudio.Core.Main.Mvvm;
using ForensicStudio.DataAccess.Model.Core;

namespace ForensicStudio.Service.Core.Repository;

public interface IRepositoryService<TDbModel> : IService where TDbModel : IDbModel
{
    Task<IEnumerable<TDbModel>> GetAllAsync();
    Task<TDbModel> GetByIdAsync(int id);
    IQueryable<T> GetQueryable<T>() where T : class, IDbModel;
    void Add(TDbModel dbModel);
    void Remove(TDbModel dbModel);
    Task SaveAsync();
    Task<bool> CanRemove(TDbModel dbModel);
    bool HasChanges();
}