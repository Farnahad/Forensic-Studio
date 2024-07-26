using Prism.Ioc;

namespace ForensicStudio.Service.Core.Container;

public class ContainerService : IContainerService
{
    private IContainerExtension _containerExtension;

    public ContainerService(IContainerExtension containerExtension)
    {
        _containerExtension = containerExtension;
    }

    public T Resolve<T>()
    {
        return _containerExtension.Resolve<T>();
    }

    public object Resolve(Type type)
    {
        return _containerExtension.Resolve(type);
    }

    public void Register<T>()
    {
        _containerExtension.Register<T>();
    }

    public void Register(Type type)
    {
        _containerExtension.Register(type);
    }

    public bool IsRegistered<T>()
    {
        return IsRegistered(typeof(T));
    }

    public bool IsRegistered(Type type)
    {
        return _containerExtension.IsRegistered(type);
    }

    public void RegisterDialog<T>()
    {
        _containerExtension.RegisterDialog<T>();
    }

    public void RegisterNavigation<T>()
    {
        _containerExtension.RegisterForNavigation<T>();
    }

    public void Dispose()
    {
        _containerExtension = null;
    }
}