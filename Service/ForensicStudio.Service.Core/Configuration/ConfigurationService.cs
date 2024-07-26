using Microsoft.Extensions.Configuration;

namespace ForensicStudio.Service.Core.Configuration;

public class ConfigurationService : IConfigurationService
{
    private readonly IConfigurationRoot _configurationRoot;

    public ConfigurationService()
    {
        _configurationRoot = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }

    public string GetConnectionString(string name)
    {
        return _configurationRoot.GetConnectionString(name);
    }

    public void Dispose()
    {
    }
}