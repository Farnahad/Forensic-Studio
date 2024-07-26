using ForensicStudio.Core.Main.Mvvm;

namespace ForensicStudio.Service.Core.Configuration;

public interface IConfigurationService : IService
{
    string GetConnectionString(string name);
}