using ForensicStudio.Core.Main.Mvvm;

namespace ForensicStudio.Service.Core.Container;

public interface IContainerService : IService
{
    T Resolve<T>();
    object Resolve(Type type);
    void Register<T>();
    void Register(Type type);
    bool IsRegistered<T>();
    bool IsRegistered(Type type);
    void RegisterDialog<T>();
    void RegisterNavigation<T>();
}