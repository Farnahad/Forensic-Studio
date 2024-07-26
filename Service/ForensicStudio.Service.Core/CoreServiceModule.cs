using ForensicStudio.DataAccess.Data;
using ForensicStudio.Service.Core.Configuration;
using ForensicStudio.Service.Core.Container;
using ForensicStudio.Service.Core.Crud;
using ForensicStudio.Service.Core.Repository;
using Prism.Ioc;
using Prism.Modularity;

namespace ForensicStudio.Service.Core;

public class CoreServiceModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IConfigurationService, ConfigurationService>();
        containerRegistry.Register<IContainerService, ContainerService>();
        containerRegistry.Register<ForensicStudioSqliteDbContext>();
        containerRegistry.Register(typeof(IRepositoryService<>), typeof(SqlServerRepositoryService<>));
        containerRegistry.Register(typeof(ICrudService<>), typeof(CrudService<>));
        containerRegistry.Register<ForensicStudioSqlServerDbContext>(containerProvider =>
        {
            var configurationService = containerProvider.Resolve<IConfigurationService>();
            return new ForensicStudioSqlServerDbContext(
                configurationService.GetConnectionString("ForensicStudioSqlServer"));
        });
    }
}